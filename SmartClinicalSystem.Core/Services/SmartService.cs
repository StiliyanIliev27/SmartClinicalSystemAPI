using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OpenAI;
using OpenAI.Chat;
using SmartClinicalSystem.Core.Configs;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.DTOs.Medicine;
using SmartClinicalSystem.Core.Helpers;
using SmartClinicalSystem.Core.Queries.AI;
using SmartClinicalSystem.Infrastructure.Data.Enums;
using SmartClinicalSystem.Infrastructure.Data.Models;
using System.Text.Json;

namespace SmartClinicalSystem.Core.Services
{
    public class SmartService : ISmartService
    {
        private readonly OpenAIClient client;
        private readonly string model;
        private readonly IRepository repository;

        public SmartService(OpenAIClient client, IRepository repository, IOptions<OpenAiOptions> options)
        {
            this.client = client;
            this.repository = repository;
            model = options.Value.Model;
        }
        public async Task<DiagnoseResultDto?> GetDiagnosisAsync(string symptoms)
        {
            // Load available medicines from DB
            var medicines = await repository
                .AllReadOnly<Medicine>()
                .Where(m => !m.IsDeleted && m.StockQuantity > 0)
                .Select(m => new
                {
                    m.MedicineId,
                    m.GenericName,
                    m.Category,
                    m.DosageForm,
                    m.Strength,
                    m.Manufacturer,
                    m.Description,
                    m.Indications,
                    m.SideEffects,
                    m.Precautions,
                    m.Price,
                    m.AiSummary,
                    m.Contraindications
                })
                .ToListAsync();

            if (!medicines.Any())
                return new DiagnoseResultDto("No medicines available.", Enumerable.Empty<GetMedicinesAiConsultationDTO>(), "No medicines are currently in stock.");

            // Build a structured medicine context string for the AI
            var medicineList = string.Join("\n", medicines.Select(m =>
            $"""
                - ID: {m.MedicineId}
                  Name: {m.GenericName}
                  Category: {m.Category}
                  Form: {m.DosageForm}
                  Strength: {m.Strength}
                  Manufacturer: {m.Manufacturer}
                  Indications: {m.Indications}
                  SideEffects: {m.SideEffects}
            """));

            // Fetch AI prompt from PromptTemplate table (dynamic)
            var promptTemplate = await repository
                .AllReadOnly<PromptTemplate>()
                .Where(p => p.Type == PromptTemplateType.Diagnose && !p.IsDeleted)
                .OrderByDescending(p => p.CreatedAt)
                .FirstOrDefaultAsync();

            var systemPrompt = promptTemplate?.Content ?? 
            """
                You are a medical assistant AI for a Smart Medical System.
                Choose medicines ONLY from the provided list, using their IDs.
                Respond strictly in JSON format:
                {
                    "possibleConditions": "string",
                    "recommendedMedicineIds": ["id1","id2"],
                    "advice": "string"
                }
            """;

            // Prepare the chat client and messages
            var chatClient = client.GetChatClient(model); // model injected from config
            var messages = new List<ChatMessage>
            {
                ChatMessage.CreateSystemMessage(systemPrompt),
                ChatMessage.CreateUserMessage($"Symptoms: {symptoms}\nAvailable medicines:\n{medicineList}")
            };

            // Send to GPT
            var response = await chatClient.CompleteChatAsync(messages);
            var content = response.Value.Content?[0].Text;

            if (string.IsNullOrWhiteSpace(content))
                return null;

            // Try to deserialize AI output
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            AiDiagnosisIntermediate? aiResult = null;

            try
            {
                aiResult = JsonSerializer.Deserialize<AiDiagnosisIntermediate>(content, options);
            }
            catch (JsonException)
            {
                var jsonStart = content.IndexOf('{');
                var jsonEnd = content.LastIndexOf('}');
                if (jsonStart >= 0 && jsonEnd > jsonStart)
                {
                    var json = content.Substring(jsonStart, jsonEnd - jsonStart + 1);
                    aiResult = JsonSerializer.Deserialize<AiDiagnosisIntermediate>(json, options);
                }
            }

            if (aiResult == null)
                return new DiagnoseResultDto("Unable to parse AI response.", Enumerable.Empty<GetMedicinesAiConsultationDTO>(), content);

            // Match recommended medicine IDs to your database list
            var recommendedMeds = medicines
                .Where(m => aiResult.RecommendedMedicineIds.Contains(m.MedicineId))
                .Select(m => new GetMedicinesAiConsultationDTO()
                {
                    MedicineId = m.MedicineId,
                    GenericName = m.GenericName,
                    Category = m.Category.ToString(),
                    DosageForm = m.DosageForm,
                    Strength = m.Strength,
                    Manufacturer = m.Manufacturer,
                    Description = m.Description,
                    Indications = m.Indications,
                    SideEffects = m.SideEffects,
                    Precautions = m.Precautions,
                    Price = m.Price,
                    AiSummary = m.AiSummary,
                    Contraindications = m.Contraindications
                })
                .ToList();

            // Return final structured result
            return new DiagnoseResultDto(
                aiResult.PossibleConditions,
                recommendedMeds,
                aiResult.Advice
            );
        }
    }
}
