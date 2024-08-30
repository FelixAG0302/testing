using AutoMapper;
using testing.Application.Contracts.Persistance;
using testing.Application.Core;
using testing.Application.Models.ClassRoom;
using testing.Application.Models.ClassroomSubject;
using testing.Domain.Entities;
using testing.Domain.Repositories.Persistance;

namespace testing.Application.Services.Persistance
{
    public class ClassRoomSubjectService : BaseService<SaveClassRoomSubjectModel, ClassRoomSubject>, IClassRoomSubjectService
    {
        private readonly IClassRoomSubjectRepository _classRoomSubjectRepository;
        private readonly IMapper _mapper;

        public ClassRoomSubjectService(IClassRoomSubjectRepository classRoomSubjectRepository, IMapper mapper) : base(classRoomSubjectRepository, mapper)
        {
            _classRoomSubjectRepository = classRoomSubjectRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<ClassRoomSubject>>> FilterAsync(FilterClassRoomSubjectModel filterModel)
        {
            Result<List<ClassRoomSubject>> result = new();
            try
            {
                List<ClassRoomSubject> entitiesGetted = await _classRoomSubjectRepository.Filter(filterModel.degreeId, filterModel.TeacherId, filterModel.ClassRoomCode, filterModel.Day);

                List<ClassRoomModel> mappedEntities = _mapper.Map<List<ClassRoomModel>>(entitiesGetted);

                result.Message = "Filter Succesfull";
                return result;
            }
            catch
            {
                result.IsSuccess = false;
                result.Message = "Critical error filtering the sections";
                return result;
            }
        }
    }
}
