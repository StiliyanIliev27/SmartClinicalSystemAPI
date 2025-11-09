using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OpenAI;
using OpenAI.Chat;
using SmartClinicalSystem.Core.Configs;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.DTOs.Doctor;
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

            var systemPrompt = promptTemplate!.Content;

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
                    json = json.Replace("`", "").Replace("'", "\"").Trim();
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

        public async Task<DiagnosisForMedicalReceiptDto?> GetDiagnosisForMedicalReceiptAsync(MedicalReceipt medicalReceipt)
        {
            var medicineIds = medicalReceipt.MedicalReceiptsMedicines.Select(rm => rm.MedicineId).Distinct().ToList();

            var medicines = await repository
                .AllReadOnly<Medicine>()
                .Where(m => !m.IsDeleted && medicineIds.Contains(m.MedicineId))
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
                    m.Contraindications
                })
                .ToListAsync();

                if (!medicines.Any())
                    return new DiagnosisForMedicalReceiptDto()
                    {
                        AiDiagnosis = "No valid medicines found for this receipt.",
                        AiAdvice = "Ensure medicines are correctly linked before AI analysis."
                    };


            var medicineList = string.Join("\n", medicines.Select(m =>
            $"""
                - ID: {m.MedicineId}
                  Name: {m.GenericName}
                  Category: {m.Category}
                  Form: {m.DosageForm}
                  Strength: {m.Strength}
                  Indications: {m.Indications}
                  SideEffects: {m.SideEffects}
                  Precautions: {m.Precautions}
                  Contraindications: {m.Contraindications}
            """));

            var promptTemplate = await repository
                .AllReadOnly<PromptTemplate>()
                .Where(p => p.Type == PromptTemplateType.ReceiptAnalysis && !p.IsDeleted)
                .OrderByDescending(p => p.CreatedAt)
                .FirstOrDefaultAsync();

            var systemPrompt = promptTemplate!.Content;

            var chatClient = client.GetChatClient(model);

            var userMessage = 
            $"""
                Doctor's diagnosis: {medicalReceipt.Diagnosis}
                Doctor's advice: {medicalReceipt.Advice}

                Prescribed medicines:
                {medicineList}
            """;

            var messages = new List<ChatMessage>
            {
                ChatMessage.CreateSystemMessage(systemPrompt),
                ChatMessage.CreateUserMessage(userMessage)
            };

            var response = await chatClient.CompleteChatAsync(messages);
            var content = response.Value.Content?[0].Text;

            if (string.IsNullOrWhiteSpace(content))
                return null;

            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            DiagnosisForMedicalReceiptDto? aiResult = null;

            try
            {
                aiResult = JsonSerializer.Deserialize<DiagnosisForMedicalReceiptDto>(content, jsonOptions);
            }
            catch (JsonException)
            {
                // Clean AI output in case it includes markdown, quotes, or extra text
                var jsonStart = content.IndexOf('{');
                var jsonEnd = content.LastIndexOf('}');

                if (jsonStart >= 0 && jsonEnd > jsonStart)
                {
                    var json = content.Substring(jsonStart, jsonEnd - jsonStart + 1);
                    json = json.Replace("`", "").Replace("'", "\"").Trim(); 
                    aiResult = JsonSerializer.Deserialize<DiagnosisForMedicalReceiptDto>(json, jsonOptions);
                }
            }

            if (aiResult == null)
            {
                return new DiagnosisForMedicalReceiptDto
                {
                    AiDiagnosis = "Unable to parse AI output.",
                    AiAdvice = content ?? "No response."
                };
            }

            return aiResult;
        }
    }
}
