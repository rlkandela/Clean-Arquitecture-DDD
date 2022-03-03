using CleanArquitecture.Identity.Configurations;
using CleanArquitecture.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArquitecture.Identity
{
    public class CleanArquitectureIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public CleanArquitectureIdentityDbContext(DbContextOptions<CleanArquitectureIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
