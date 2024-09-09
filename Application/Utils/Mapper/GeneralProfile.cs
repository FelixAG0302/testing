
using Mapster;
using testing.Application.Models.ClassRoom;
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
