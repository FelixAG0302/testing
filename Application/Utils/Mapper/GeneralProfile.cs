
using Mapster;
using testing.Application.Features.Application.ClassRoomFeature.Models;
using testing.Domain.Entities;

namespace testing.Application.Utils.Mapper
{
    public static class GeneralProfile 
    {
       public static void Configure()
        {
            TypeAdapterConfig<ClassRoom, ClassRoomModel>.NewConfig();
        }
    }
}
