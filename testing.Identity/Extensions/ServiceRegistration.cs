

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using testing.Identity.Context;

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
        }
    }
}
