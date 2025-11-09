using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Infrastructure.Data.Configurations
{
    internal class MedicalReceiptsMedicineConfiguration : IEntityTypeConfiguration<MedicalReceiptMedicine>
    {
        public void Configure(EntityTypeBuilder<MedicalReceiptMedicine> builder)
        {
            builder.HasKey(rm => rm.ReceiptMedicineId);

            builder
                .HasOne(rm => rm.MedicalReceipt)
                .WithMany(r => r.MedicalReceiptsMedicines)
                .HasForeignKey(rm => rm.MedicalReceiptId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(rm => rm.Medicine)
                .WithMany()
                .HasForeignKey(rm => rm.MedicineId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
