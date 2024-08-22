using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using testing.Application.Contracts.Persistance;
using testing.Application.Services.Persistance;


namespace testing.Application.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IClassRoomService, ClassRoomService>();
            services.AddTransient<IClassRoomSubjectService, ClassRoomSubjectService>();
            services.AddTransient<IDegreeService, DegreeService>();
            services.AddTransient<IDegreeSubjectService, DegreeSubjectService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<ITeacherSubjectService, TeacherSubjectService>();
            services.AddTransient<IUserScheduleService, UserScheduleService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
