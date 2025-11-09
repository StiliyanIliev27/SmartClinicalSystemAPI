using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartClinicalSystem.Infrastructure.Data.Models;
using SmartClinicalSystem.Infrastructure.Data.Seed;

namespace SmartClinicalSystem.Infrastructure.Data.Configurations
{
    internal class MedicalReceiptsConfiguration : IEntityTypeConfiguration<MedicalReceipt>
    {
        public void Configure(EntityTypeBuilder<MedicalReceipt> builder)
        {
            builder.HasData(new SeedData().MedicalReceipts);
        }
    }
}
