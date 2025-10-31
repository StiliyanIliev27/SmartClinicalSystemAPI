using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartClinicalSystem.Infrastructure.Data.Seed;

namespace SmartClinicalSystem.Infrastructure.Data.Configurations
{
    internal class UserRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new SeedData().UsersRoles);
        }
    }
}
