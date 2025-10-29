using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Infrastructure.Data.Enums;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Infrastructure.Data
{
    public class SmartClinicalSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public SmartClinicalSystemDbContext(DbContextOptions<SmartClinicalSystemDbContext> options)
              : base(options)
        {
        }
        public DbSet<Medicine> Medicines { get; set; } = null!;
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;


        public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var userRoleId = "4f8554d2-cfaa-44b5-90ce-e883c804ae90";
            var adminRoleId = "656a6079-ec9a-4a98-a484-2d1752156d60";

            // Seed the roles using HasData
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId,
                    Name = "User",
                    NormalizedName = "USER",
                },
                new IdentityRole
                {
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                }
            );

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "admin-user-id",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@admin.com",
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null!, "admin123"),
                }
            );

            // Seed data for the Medicine entity
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine
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
                },
                new Medicine
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
                },
                new Medicine
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
                },
                new Medicine
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
                },
                new Medicine
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
                },
                new Medicine
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
                },
                new Medicine
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
                },
                new Medicine
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
                },
                new Medicine
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
                },
                new Medicine
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
                }
            );
        }
    }
}
