using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartClinicalSystem.Infrastructure.Data.Models;
using SmartClinicalSystem.Infrastructure.Data.Seed;

namespace SmartClinicalSystem.Infrastructure.Data.Configurations
{
    internal class PromptTemplatesConfiguration : IEntityTypeConfiguration<PromptTemplate>
    {
        public void Configure(EntityTypeBuilder<PromptTemplate> builder)
        {
            builder.HasData(new SeedData().PromptTemplates);
        }
    }
}
