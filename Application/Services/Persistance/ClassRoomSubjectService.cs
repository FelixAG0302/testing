
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using testing.Application.Contracts.Persistance;
using testing.Application.Core;

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

        public async Task<Result<List<ClassRoomSubjectModel>>> FilterAsync(FilterClassRoomSubjectModel filterModel)
        {
            try
            {
                List<ClassRoomSubject> entitiesGetted = await _classRoomSubjectRepository.Filter(filterModel.degreeId, filterModel.TeacherId, filterModel.ClassRoomCode, filterModel.Day);

                return new("Filter Succesfull", _mapper.Map<List<ClassRoomSubjectModel>>(entitiesGetted));
            }
            catch
            {
                return new("Critical error filtering the sections", false);
            }
        }

        public async Task<Result<List<ClassRoomSubjectModel>>> GetTeachesSectionAsync()
        {

            if (_currentUserInfo == null) 
                return new("There is no user loged in", false);

            if (_currentUserInfo.Roles.Any(u => u == nameof(Roles.Teacher))) 
                return new("only teachers can access this resource", false);   

            try
            {
                List<ClassRoomSubject> entitiesGetted = await _classRoomSubjectRepository.GetAllByUserIdAsync(_currentUserInfo.Id);

                return new("Teachers sections were getted successfully", _mapper.Map<List<ClassRoomSubjectModel>>(entitiesGetted));
            }
            catch
            {
                return new("Critical error while getting the entities", false);
            }
        }
    }
}
