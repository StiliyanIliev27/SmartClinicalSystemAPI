using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartClinicalSystem.Infrastructure.Data.Models;
using SmartClinicalSystem.Infrastructure.Data.Seed;

namespace SmartClinicalSystem.Infrastructure.Data.Configurations
{
    internal class MedicinesConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.HasData(new SeedData().Medicines);
        }
    }
}
