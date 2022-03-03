using CleanArquitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArquitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser()
                {
                    Id = "03fd4194-e1c0-40a1-af6d-8a390a5f3e2f",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "admin@localhost.com",
                    Nombre = "rl",
                    Apellidos = "kandela",
                    UserName = "rlkandela",
                    NormalizedUserName = "rlkandela",
                    PasswordHash = hasher.HashPassword(null, "12345"),
                    EmailConfirmed = true
                },
                new ApplicationUser()
                {
                    Id = "cfd073d5-b136-43c0-84b1-2ab7059ebfb8",
                    Email = "juanperez@localhost.com",
                    NormalizedEmail = "juanperez@localhost.com",
                    Nombre = "Juan",
                    Apellidos = "Perez",
                    UserName = "juanperez",
                    NormalizedUserName = "juanperez",
                    PasswordHash = hasher.HashPassword(null, "abcdef"),
                    EmailConfirmed = true
                }
            );
        }
    }
}
