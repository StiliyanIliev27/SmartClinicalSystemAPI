using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartClinicalSystem.Infrastructure.Data.Seed;

namespace SmartClinicalSystem.Infrastructure.Data.Configurations
{
    internal class RolesConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new SeedData().Roles);
        }
    }
}
