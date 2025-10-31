using Microsoft.AspNetCore.Identity;
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
        }
        public List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
        public ICollection<IdentityRole> Roles { get; set; } = new HashSet<IdentityRole>();
        public ICollection<IdentityUserRole<string>> UsersRoles { get; set; } = new HashSet<IdentityUserRole<string>>();
        public List<Medicine> Medicines { get; set; } = new List<Medicine>();
        public List<PromptTemplate> PromptTemplates { get; set; } = new List<PromptTemplate>();

        public void SeedUsers()
        {
             var hasher = new PasswordHasher<ApplicationUser>();
        
             var adminUser = new ApplicationUser
             {
                 Id = "27d78708-8671-4b05-bd5e-17aa91392224",
                 Email = "admin@admin.com",
                 EmailConfirmed = true,
                 NormalizedEmail = "admin@admin.com".ToUpper(),
                 PasswordHash = hasher.HashPassword(null!, "admin123")
             };

             var user = new ApplicationUser
             {
                 Id = "f8472c89-f48d-49cc-8517-a81153d47cdd",
                 Email = "user@user.com",
                 EmailConfirmed = true,
                 NormalizedEmail = "user@user.com".ToUpper(),
                 PasswordHash = hasher.HashPassword(null!, "user123")
             };

            Users.Add(user);
            Users.Add(adminUser);
        }

        public void SeedRoles()
        {
            var userRoleId = "4f8554d2-cfaa-44b5-90ce-e883c804ae90";
            var adminRoleId = "656a6079-ec9a-4a98-a484-2d1752156d60";

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
            PromptTemplates.Add(new PromptTemplate
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
        }
    }
}
