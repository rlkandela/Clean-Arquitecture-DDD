using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArquitecture.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole()
                {
                    Id = "8893c817-7a98-48cb-8e79-8a79d5bd9f0f",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole()
                {
                    Id = "01d6351e-5a93-4806-9204-a0d4f15bf361",
                    Name = "User",
                    NormalizedName = "USER"
                }
            );
        }
    }
}
