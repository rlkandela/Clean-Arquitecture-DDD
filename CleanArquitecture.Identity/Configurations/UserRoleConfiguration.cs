using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArquitecture.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = "8893c817-7a98-48cb-8e79-8a79d5bd9f0f",
                    UserId = "03fd4194-e1c0-40a1-af6d-8a390a5f3e2f"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "01d6351e-5a93-4806-9204-a0d4f15bf361",
                    UserId = "cfd073d5-b136-43c0-84b1-2ab7059ebfb8"
                }
            );
        }
    }
}
