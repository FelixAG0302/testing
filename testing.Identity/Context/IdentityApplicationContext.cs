

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using testing.Identity.Entities;

namespace testing.Identity.Context
{
    public class IdentityApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityApplicationContext()
        {
            
        }
        public IdentityApplicationContext(DbContextOptions<IdentityApplicationContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=IBSCOMP124;  user Id= sa; password=biblia01**;  Database=testingApplicationUsers; TrustServerCertificate=true;", m => m.MigrationsAssembly(typeof(IdentityApplicationContext).Assembly.FullName));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
