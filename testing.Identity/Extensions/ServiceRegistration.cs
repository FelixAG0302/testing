

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using testing.Domain.Repositories.Identity;
using testing.Identity.Context;
using testing.Identity.Entities;
using testing.Identity.Repositories;

namespace testing.Identity.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddInfraestructureIdentityLayer(IServiceCollection services, IConfiguration confi)
        {
            services.AddDbContext<IdentityApplicationContext>(options =>
            {
                options.UseSqlServer(confi.GetConnectionString("DefaultIdentityConnection"), m => m.MigrationsAssembly(typeof(IdentityApplicationContext).Assembly.FullName));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<IdentityApplicationContext>().AddDefaultTokenProviders();

            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddTransient(typeof(IUserRepository<>), typeof(UserRepository));
        }
    }
}
