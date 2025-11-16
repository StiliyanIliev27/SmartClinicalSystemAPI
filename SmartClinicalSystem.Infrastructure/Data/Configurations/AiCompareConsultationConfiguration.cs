using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Infrastructure.Data.Configurations
{
    internal class AiCompareConsultationConfiguration : IEntityTypeConfiguration<AiCompareConsultation>
    {
        public void Configure(EntityTypeBuilder<AiCompareConsultation> builder)
        {
            builder.HasKey(rm => rm.Id);

            builder
                .HasOne(rm => rm.FirstMedicine)
                .WithMany()
                .HasForeignKey(rm => rm.FirstMedicineId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(rm => rm.SecondMedicine)
                .WithMany()
                .HasForeignKey(rm => rm.SecondMedicineId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
