using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using testing.Application.Contracts.Persistance;
using testing.Application.Services.Persistance;
using testing.Domain.Settings;
using Mapster;
using testing.Application.Utils.Mapper;


namespace testing.Application.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration confi)
        {
            services.AddOptions<SessionKeys>();
            services.Configure<SessionKeys>(confi.GetSection("SessionKeys"));


            services.AddTransient<IClassRoomService, ClassRoomService>();
            services.AddTransient<IClassRoomSubjectService, ClassRoomSubjectService>();
            services.AddTransient<IDegreeService, DegreeService>();
            services.AddTransient<IDegreeSubjectService, DegreeSubjectService>();
            services.AddTransient<ITeacherSubjectService, TeacherSubjectService>();
            services.AddTransient<IUserScheduleService, UserScheduleService>();

            services.AddMapster();
            GeneralProfile.Configure();




        }
    }
}
