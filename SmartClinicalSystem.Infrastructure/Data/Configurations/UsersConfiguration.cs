using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartClinicalSystem.Infrastructure.Data.Models;
using SmartClinicalSystem.Infrastructure.Data.Seed;

namespace SmartClinicalSystem.Infrastructure.Data.Configurations
{
    internal class UsersConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(new SeedData().Users);
        }
    }
}
