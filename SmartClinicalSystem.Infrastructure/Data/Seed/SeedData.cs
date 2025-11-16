using Microsoft.AspNetCore.Identity;
using SmartClinicalSystem.Infrastructure.Common;
using SmartClinicalSystem.Infrastructure.Data.Enums;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Infrastructure.Data.Seed
{
    public class SeedData
    {
        public SeedData()
        {
            SeedUsers();
            SeedRoles();
            SeedUserRoles();
            SeedMedicines();
            SeedPromptTemplates();
            SeedMedicalReceipts();
        }
        public List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
        public ICollection<IdentityRole> Roles { get; set; } = new HashSet<IdentityRole>();
        public ICollection<IdentityUserRole<string>> UsersRoles { get; set; } = new HashSet<IdentityUserRole<string>>();
        public List<Medicine> Medicines { get; set; } = new List<Medicine>();
        public List<PromptTemplate> PromptTemplates { get; set; } = new List<PromptTemplate>();
        public List<MedicalReceipt> MedicalReceipts { get; set; } = new List<MedicalReceipt>();
        public List<MedicalReceiptMedicine> MedicalReceiptMedicines { get; set; } = new List<MedicalReceiptMedicine>();

        public void SeedUsers()
        {
             var hasher = new PasswordHasher<ApplicationUser>();
        
             var adminUser = new ApplicationUser
             {
                 Id = "27d78708-8671-4b05-bd5e-17aa91392224",
                 UserName = "admin_adminov",
                 NormalizedUserName = "admin_adminov".ToUpper(),
                 Email = "admin@admin.com",
                 EmailConfirmed = true,
                 NormalizedEmail = "admin@admin.com".ToUpper(),
                 PasswordHash = hasher.HashPassword(null!, "admin123")
             };

             var user = new ApplicationUser
             {
                 Id = "f8472c89-f48d-49cc-8517-a81153d47cdd",
                 UserName = "user_userov",
                 NormalizedUserName = "user_userov".ToUpper(),
                 Email = "user@user.com",
                 EmailConfirmed = true,
                 NormalizedEmail = "user@user.com".ToUpper(),
                 PasswordHash = hasher.HashPassword(null!, "user123")
             };

            var doctor = new ApplicationUser
            {
                Id = "bc0c48b7-5cb9-4d8f-802b-68bea5bf4780",
                UserName = "doctor_doctorov",
                NormalizedUserName = "doctor_doctorov".ToUpper(),
                Email = "doctor@doctor.com",
                EmailConfirmed = true,
                NormalizedEmail = "doctor@doctor.com".ToUpper(),
                PasswordHash = hasher.HashPassword(null!, "doctor123")
            };

            Users.Add(user);
            Users.Add(adminUser);
            Users.Add(doctor);
        }

        public void SeedRoles()
        {
            var userRoleId = "4f8554d2-cfaa-44b5-90ce-e883c804ae90";
            var adminRoleId = "656a6079-ec9a-4a98-a484-2d1752156d60";
            var doctorRoleId = "50622ab4-fb1c-41b3-87f0-a225bd75e2a6";

            // Seed the roles in the Database if they do not exist
            Roles.Add(new IdentityRole
            {
                Id = userRoleId,
                ConcurrencyStamp = userRoleId,
                Name = "User",
                NormalizedName = "USER",
            });
            Roles.Add(new IdentityRole
            {
                Id = adminRoleId,
                ConcurrencyStamp = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
            });
            Roles.Add(new IdentityRole
            {
                Id = doctorRoleId,
                ConcurrencyStamp = doctorRoleId,
                Name = "Doctor",
                NormalizedName = "DOCTOR",
            });
        }
        
        private void SeedUserRoles()
        {
            UsersRoles.Add(new IdentityUserRole<string> // Test User Role
            {
                UserId = "f8472c89-f48d-49cc-8517-a81153d47cdd",
                RoleId = "4f8554d2-cfaa-44b5-90ce-e883c804ae90"
            });
            UsersRoles.Add(new IdentityUserRole<string> // Admin User Role
            {
                UserId = "27d78708-8671-4b05-bd5e-17aa91392224",
                RoleId = "656a6079-ec9a-4a98-a484-2d1752156d60"
            });
            UsersRoles.Add(new IdentityUserRole<string> // Admin User with Doctor Role
            {
                UserId = "27d78708-8671-4b05-bd5e-17aa91392224",
                RoleId = "50622ab4-fb1c-41b3-87f0-a225bd75e2a6"
            });
            UsersRoles.Add(new IdentityUserRole<string> // Doctor User Role
            {
                UserId = "bc0c48b7-5cb9-4d8f-802b-68bea5bf4780",
                RoleId = "50622ab4-fb1c-41b3-87f0-a225bd75e2a6"
            });
        }

        private void SeedMedicines()
        {
            Medicines.Add(new Medicine
            {
                MedicineId = "1a2b3c4d-5e6f-7g8h-9i0j-1k2l3m4n5o6p",
                GenericName = "Paracetamol",
                Category = MedicineCategory.Analgesics,
                DosageForm = "Tablet",
                Strength = "500mg",
                Manufacturer = "PharmaCorp",
                Price = 2.5m,
                StockQuantity = 100,
                CreatedAt = DateTime.UtcNow
            });
            Medicines.Add(new Medicine
            {
                MedicineId = "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                GenericName = "Ibuprofen",
                Category = MedicineCategory.Analgesics,
                DosageForm = "Capsule",
                Strength = "200mg",
                Manufacturer = "HealthMeds",
                Price = 3.0m,
                StockQuantity = 200,
                CreatedAt = DateTime.UtcNow
            });
            Medicines.Add(new Medicine
            {
                MedicineId = "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                GenericName = "Amoxicillin",
                Category = MedicineCategory.Antibiotics,
                DosageForm = "Capsule",
                Strength = "250mg",
                Manufacturer = "MediLife",
                Price = 5.0m,
                StockQuantity = 150,
                CreatedAt = DateTime.UtcNow
            });
            Medicines.Add(new Medicine
            {
                MedicineId = "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s",
                GenericName = "Acyclovir",
                Category = MedicineCategory.Antivirals,
                DosageForm = "Tablet",
                Strength = "400mg",
                Manufacturer = "ViralPharma",
                Price = 8.0m,
                StockQuantity = 50,
                CreatedAt = DateTime.UtcNow
            });
            Medicines.Add(new Medicine
            {
                MedicineId = "5e6f7g8h-9i0j-1k2l-3m4n-5o6p7q8r9s0t",
                GenericName = "Fluconazole",
                Category = MedicineCategory.Antifungals,
                DosageForm = "Capsule",
                Strength = "150mg",
                Manufacturer = "FungalCare",
                Price = 6.0m,
                StockQuantity = 75,
                CreatedAt = DateTime.UtcNow
            });
            Medicines.Add(new Medicine
            {
                MedicineId = "6f7g8h9i-0j1k-2l3m-4n5o-6p7q8r9s0t1u",
                GenericName = "Metformin",
                Category = MedicineCategory.Antidiabetics,
                DosageForm = "Tablet",
                Strength = "500mg",
                Manufacturer = "DiabetesCare",
                Price = 4.0m,
                StockQuantity = 300,
                CreatedAt = DateTime.UtcNow
            });
            Medicines.Add(new Medicine
            {
                MedicineId = "7g8h9i0j-1k2l-3m4n-5o6p-7q8r9s0t1u2v",
                GenericName = "Losartan",
                Category = MedicineCategory.Antihypertensives,
                DosageForm = "Tablet",
                Strength = "50mg",
                Manufacturer = "HeartHealth",
                Price = 3.5m,
                StockQuantity = 250,
                CreatedAt = DateTime.UtcNow
            });
            Medicines.Add(new Medicine
            {
                MedicineId = "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w",
                GenericName = "Omeprazole",
                Category = MedicineCategory.Gastrointestinal,
                DosageForm = "Capsule",
                Strength = "20mg",
                Manufacturer = "DigestiveCare",
                Price = 2.0m,
                StockQuantity = 400,
                CreatedAt = DateTime.UtcNow
            });
            Medicines.Add(new Medicine
            {
                MedicineId = "9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x",
                GenericName = "Salbutamol",
                Category = MedicineCategory.Respiratory,
                DosageForm = "Inhaler",
                Strength = "100mcg",
                Manufacturer = "BreathEasy",
                Price = 10.0m,
                StockQuantity = 120,
                CreatedAt = DateTime.UtcNow
            });
            Medicines.Add(new Medicine
            {
                MedicineId = "0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y",
                GenericName = "Cetirizine",
                Category = MedicineCategory.Allergy,
                DosageForm = "Tablet",
                Strength = "10mg",
                Manufacturer = "AllergyRelief",
                Price = 1.5m,
                StockQuantity = 500,
                CreatedAt = DateTime.UtcNow
            });
        }

        private void SeedPromptTemplates()
        {
            PromptTemplates.Add(new PromptTemplate()
            {
                Name = "Default Diagnose Prompt",
                Description = "Analyzes user symptoms and recommends possible conditions and medicines from the available list.",
                Type = PromptTemplateType.Diagnose,
                Content =
                """ 
                    You are a responsible and helpful AI medical assistant for a Smart Clinical System.
                    Your role:
                    - Analyze the user's symptoms.
                    - Recommend the most appropriate medicines ONLY from the provided list (with their IDs).
                    - Provide a short and friendly advice section for the patient.

                    Follow these rules:
                    1. Never invent new medicines or diseases.
                    2. Choose only from the provided list.
                    3. Always respond **strictly in JSON** format using this structure:

                    {
                      "possibleConditions": "string — short description of likely common conditions",
                      "recommendedMedicineIds": ["9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x", "0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y"],
                      "advice": "string — short patient-friendly advice"
                    }

                    Example response:

                    {
                      "possibleConditions": "Common cold or influenza",
                      "recommendedMedicineIds": ["9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x", "0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y"],
                      "advice": "Stay hydrated, rest, and take paracetamol for fever. Consult a doctor if symptoms persist more than 3 days."
                    }

                    Do not include any text, explanation, or markdown outside the JSON block.
                """,
                CreatedAt = DateTime.Now,
                IsDeleted = false
            });
            PromptTemplates.Add(new PromptTemplate
            {
                Name = "Default Receipt Review Prompt",
                Description = "Validates a doctor's medical receipt and generates AI-based diagnosis & advice.",
                Type = PromptTemplateType.ReceiptAnalysis,
                Content =
                """
                    You are a senior clinical AI assistant reviewing a doctor's medical receipt.

                    ### Your Goals
                    1. Evaluate the doctor's diagnosis for completeness and clarity.
                    2. Refine or expand it into a more detailed but concise medical explanation.
                    3. Ensure the prescribed medicines are appropriate for the diagnosis.
                    4. Write patient-friendly advice that complements the doctor's notes — not just repeats them.

                    ### Your Response
                    Respond strictly in **JSON** format:
                    {
                      "aiDiagnosis": "Refined, detailed diagnosis in clinical terms (do not copy doctor's text verbatim)",
                      "aiAdvice": "Expanded advice with lifestyle or follow-up recommendations (friendly and medically sound)"
                    }

                    Avoid repeating the doctor's text; instead, validate and *enhance* it.
                    Keep responses short (2–3 sentences per field).         
                """,
                CreatedAt = DateTime.UtcNow
            });
            PromptTemplates.Add(new PromptTemplate
            {
                Name = "Medicine Comparison Prompt",
                Type = PromptTemplateType.MedicineComparison,
                Content =
                    """
                    You are a professional medical AI system.

                    Compare the two medicines based on how relevant they are for the given diagnosis.

                    For each medicine:
                    - Analyze indications relevance
                    - Match diagnosis keywords
                    - Score relevance from 0 to 10
                    - Provide matched keywords
    
                    Respond STRICTLY in JSON using this structure:

                    {
                        "diagnosis": "string",
                        "a": {
                            "medicineId": "id1",
                            "matchScore": 0,
                            "matchingKeywords": ["word1","word2"]
                        },
                        "b": {
                            "medicineId": "id2",
                            "matchScore": 0,
                            "matchingKeywords": ["word1"]
                        },
                        "betterMedicineId": "id1",
                        "explanation": "string"
                    }
                    """
            });
            PromptTemplates.Add(new PromptTemplate
            {
                Name = "Health Summary Check Prompt",
                Type = PromptTemplateType.SummaryCheck, 
                Content =
                    """
                    You are a professional AI health assistant working in a Smart Clinical System.

                    Your task:
                    Analyze the user's medical receipts AND personal health logs for the given time period.
                    Consider:
                    - Reported symptoms
                    - Pain levels
                    - Mood logs
                    - Temperatures
                    - Notes written by the user
                    - Side effects
                    - Medications prescribed in the receipts
                    - Consistency or worsening of symptoms

                    Your goal:
                    Produce a clear, friendly, medically helpful health summary (4–6 sentences).
                    Do NOT diagnose new illnesses. Base everything STRICTLY on the provided data.

                    Respond STRICTLY in JSON using the following structure:

                    {
                        "timePeriodDays": number,
                        "summary": "string (4–6 sentences summarizing health trends)",
                        "keyConcerns": ["string", "string"],
                        "positiveTrends": ["string", "string"],
                        "recommendedActions": ["string", "string"]
                    }

                    Rules:
                    - No markdown
                    - No extra text outside JSON
                    - No invented data
                    - Summaries must directly refer to the provided logs and receipts
                    """
            });


        }

        private void SeedMedicalReceipts()
        {
            MedicalReceipts.AddRange(new[]
            {
                new MedicalReceipt
                {
                    MedicalReceiptId = "rec-1",
                    DoctorId = "bc0c48b7-5cb9-4d8f-802b-68bea5bf4780",
                    PatientId = "f8472c89-f48d-49cc-8517-a81153d47cdd",
                    Diagnosis = "Viral Pharyngitis",
                    Advice = "Take rest and drink fluids.",
                    AiDiagnosis = "Possible viral infection",
                    AiAdvice = "Increase hydration and rest.",
                    IssueDate = DateTime.Now,
                    ExpirationDate = DateTime.Now.AddDays(7),
                    CreatedAt = DateTime.Now    ,
                    IsDeleted = false
                },
                new MedicalReceipt
                {
                    MedicalReceiptId = "rec-2",
                    DoctorId = "bc0c48b7-5cb9-4d8f-802b-68bea5bf4780",
                    PatientId = "f8472c89-f48d-49cc-8517-a81153d47cdd",
                    Diagnosis = "Bacterial Tonsillitis",
                    Advice = "Complete the antibiotic course.",
                    AiDiagnosis = "Possible bacterial tonsillitis",
                    AiAdvice = "Avoid spicy foods.",
                    IssueDate = DateTime.Now,
                    ExpirationDate = DateTime.Now.AddDays(10),
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                }
            });
        }

        private void SeedMedicalReceiptMedicines()
        {
            MedicalReceiptMedicines.AddRange(new[]
            {
                new MedicalReceiptMedicine
                {
                    ReceiptMedicineId = "rm-1",
                    MedicalReceiptId = "rec-1",
                    MedicineId = "1a2b3c4d-5e6f-7g8h-9i0j-1k2l3m4n5o6p",
                    Quantity = 10,
                    DosageInstructions = "1 tablet twice daily after meals",
                    DurationDays = 5
                },
                new MedicalReceiptMedicine
                {
                    ReceiptMedicineId = "rm-2",
                    MedicalReceiptId = "rec-1",
                    MedicineId = "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                    Quantity = 14,
                    DosageInstructions = "1 capsule every 8 hours",
                    DurationDays = 7
                },
                new MedicalReceiptMedicine
                {
                    ReceiptMedicineId = "rm-3",
                    MedicalReceiptId = "rec-2",
                    MedicineId = "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                    Quantity = 21,
                    DosageInstructions = "1 capsule every 8 hours",
                    DurationDays = 7
                }
            });
        }

    }
}
