using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Infrastructure.Data.Configurations;
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
        public DbSet<PromptTemplate> PromptTemplates { get; set; } = null!;
        public DbSet<AiDiagnosisConsultation> AiDiagnosisConsultations { get; set; } = null!;
        public DbSet<AiCompareConsultation> AiCompareConsultations { get; set; } = null!;
        public DbSet<AiSummaryCheckerConsultation> AiSummaryCheckerConsultations { get; set; } = null!;
        public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
        public DbSet<MedicalReceipt> MedicalReceipts { get; set; } = null!;
        public DbSet<MedicalReceiptMedicine> MedicalReceiptsMedicines { get; set; } = null!;
        public DbSet<UserHealthLog> UserHealthLogs { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MedicinesConfiguration());
            modelBuilder.ApplyConfiguration(new PromptTemplatesConfiguration());
            modelBuilder.ApplyConfiguration(new RolesConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new UserRolesConfiguration());
            modelBuilder.ApplyConfiguration(new MedicalReceiptsConfiguration());
            modelBuilder.ApplyConfiguration(new MedicalReceiptsMedicineConfiguration());
            modelBuilder.ApplyConfiguration(new AiCompareConsultationConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
