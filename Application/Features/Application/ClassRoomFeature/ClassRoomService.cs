
using MapsterMapper;
using testing.Application.Core;
using testing.Application.Features.Application.ClassRoomFeature.Models;
using testing.Application.Utils.StringGenerator;
using testing.Domain.Repositories.Persistance;

namespace testing.Application.Features.Application.ClassRoomFeature
{
    public class ClassRoomService : BaseCompleteService<ClassRoomModel, SaveClassRoomModel, Domain.Entities.ClassRoom>, IClassRoomService
    {
        private readonly IClassRoomRepository _classRoomRepository;
        public ClassRoomService(IClassRoomRepository classRoomRepository, IMapper mapper) : base(classRoomRepository, mapper)
        {
            _classRoomRepository = classRoomRepository;
        }

        public override Task<Result> SaveAsync(SaveClassRoomModel entity)
        {
            entity.Code = StringGenerator.RandomClassroomCodeGenerator();
            return base.SaveAsync(entity);
        }


    }
}
