
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using testing.Domain.Repositories.Persistance;
using testing.Infraestructure.Repositries;

namespace testing.Infraestructure.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddInfraestructureLayer(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AplicationContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"), m => m.MigrationsAssembly(typeof(AplicationContext).Assembly.FullName));
            });

            services.AddTransient<IUserScheduleRepository, UserScheduleRepository>();
            services.AddTransient<IClassRoomRepository, ClassRoomRepository>();
            services.AddTransient<IClassRoomSubjectRepository, ClassRoomSubjectRepository>();
            services.AddTransient<IDegreeRepository, DegreeRepository>();
            services.AddTransient<IDegreeSubjectRepository, DegreeSubjectRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<ITeacherSubjectRepository, TeacherSubjectRepository>();
            services.AddTransient<IUserScheduleRepository, UserScheduleRepository>();
            services.AddTransient<IUserScheduleSectionRepository, UserScheduleSectionRepository>();
            services.AddTransient<IUserDegreeRepository, UserDegreeRepository>();

        }
    }
}

