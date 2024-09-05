
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using testing.Application.Contracts.Persistance;
using testing.Application.Core;
using testing.Application.Models.ClassRoom;
using testing.Application.Models.ClassroomSubject;
using testing.Application.Utils.SessionHandler;
using testing.Domain.Entities;
using testing.Domain.Model;
using testing.Domain.Repositories.Persistance;
using testing.Domain.Settings;
using testing.Identity.Enums;

namespace testing.Application.Services.Persistance
{
    public class ClassRoomSubjectService : BaseService<SaveClassRoomSubjectModel, ClassRoomSubject>, IClassRoomSubjectService
    {
        private readonly IClassRoomSubjectRepository _classRoomSubjectRepository;
        private readonly IMapper _mapper;
        private readonly AuthenticationResponce _currentUserInfo;
        private readonly SessionKeys _sessionKeys;

        public ClassRoomSubjectService(IClassRoomSubjectRepository classRoomSubjectRepository, IMapper mapper, ISession session, IOptions<SessionKeys> sessionkeys) : base(classRoomSubjectRepository, mapper)
        {
            _classRoomSubjectRepository = classRoomSubjectRepository;
            _mapper = mapper;
            _sessionKeys = sessionkeys.Value;
            _currentUserInfo = session.Get<AuthenticationResponce>(_sessionKeys.UserKey);
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

        public async Task<Result<List<ClassRoomSubjectModel>>> GetTeachesSectionAsync()
        {
            Result<List<ClassRoomSubjectModel>> result = new();
            if (_currentUserInfo == null)
            {
                result.IsSuccess = false;
                result.Message = "There is no user loged in";
                return result;
            }
            if(_currentUserInfo.Roles.Any(u => u == nameof(Roles.Teacher)))
            {
                result.IsSuccess = false;
                result.Message = "only teachers can access this resource";
                return result;
            }
            try
            {

                List<ClassRoomSubject> entitiesGetted = await _classRoomSubjectRepository.GetAllByUserIdAsync(_currentUserInfo.Id);

                result.Data = _mapper.Map<List<ClassRoomSubjectModel>>(entitiesGetted);

                result.Message = "Teachers sections were getted successfully";
                return result;
            }
            catch
            {
                result.IsSuccess = false;
                result.Message = "Critical error while getting the entities";
                return result;
            }
        }
    }
}
