
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using testing.Domain.Settings;
using Mapster;
using testing.Application.Utils.Mapper;
using testing.Application.Features.Application.ClassRoomFeature;
using testing.Application.Features.Application.ClassRoomSubjectFeature;
using testing.Application.Features.Application.DegreeFeature;
using testing.Application.Features.Application.DegreeSubjectFeature;
using testing.Application.Features.Application.TeacherSubjectFeature;
using testing.Application.Features.Application.UserScheduleFeature;
using testing.Application.Features.Application.UserDegreeFeature;
using testing.Application.Features.Application.SubjectFeature;
using testing.Application.Features.Application.UserScheduleSectionFeature;


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
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<IUserScheduleService, UserScheduleService>();
            services.AddTransient<IUserScheduleSectionService, UserScheduleSectionService>();
            services.AddTransient<IUserDegreeService, UserDegreeService>();

            services.AddMapster();
            GeneralProfile.Configure();




        }
    }
}
