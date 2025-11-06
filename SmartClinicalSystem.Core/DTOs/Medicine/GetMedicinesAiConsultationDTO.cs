using SmartClinicalSystem.Infrastructure.Data.Enums;
namespace SmartClinicalSystem.Core.DTOs.Medicine
{
    public class GetMedicinesAiConsultationDTO
    {
        public string MedicineId { get; set; } = null!;
        public string GenericName { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string DosageForm { get; set; } = null!;
        public string Strength { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;

        // Commercial / management info
        public decimal Price { get; set; }

        // Extended medical info
        public string? Description { get; set; }               // AI can summarize this
        public string? Indications { get; set; }               // What conditions it treats
        public string? Contraindications { get; set; }         // When not to use
        public string? SideEffects { get; set; }               // Common side effects
        public string? Precautions { get; set; }               // Important notes

        // AI-related metadata
        public string? AiSummary { get; set; }                 // GPT-generated readable summary. When AI last processed it
    }
}
