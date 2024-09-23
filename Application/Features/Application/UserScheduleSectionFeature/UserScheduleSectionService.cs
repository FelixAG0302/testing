
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using testing.Application.Core;
using testing.Application.Extensions;
using testing.Application.Features.Application.ClassRoomSubjectFeature;
using testing.Application.Features.Application.ClassRoomSubjectFeature.Models;
using testing.Application.Features.Application.UserScheduleSectionFeature.Models;
using testing.Application.Utils.Enums;
using testing.Application.Utils.SessionHandler;
using testing.Domain.Entities;
using testing.Domain.Model;
using testing.Domain.Repositories.Persistance;
using testing.Domain.Settings;
using static System.Collections.Specialized.BitVector32;

namespace testing.Application.Features.Application.UserScheduleSectionFeature
{
    public class UserScheduleSectionService : BaseService<SaveUserScheduleSectionModel, UserScheduleSection>, IUserScheduleSectionService
    {
        private readonly IUserScheduleSectionRepository _userScheduleSectionRepository;
        private readonly IClassRoomSubjectRepository _classRoomSubjectRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly SessionKeys _sessionKeys;
        private readonly AuthenticationResponce _currentUserInfo;

        public UserScheduleSectionService(IUserScheduleSectionRepository userScheduleSectionRepository, IClassRoomSubjectRepository classRoomSubjectRepository, IHttpContextAccessor httpContextAccessor, IOptions<SessionKeys> sessionKeys, IMapper mapper) : base(userScheduleSectionRepository, mapper)
        {
            _userScheduleSectionRepository = userScheduleSectionRepository;
            _classRoomSubjectRepository = classRoomSubjectRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _sessionKeys = sessionKeys.Value;
            _currentUserInfo = httpContextAccessor.HttpContext.Session.Get<AuthenticationResponce>(_sessionKeys.UserKey);
        }

        public override async Task<Result> SaveAsync(SaveUserScheduleSectionModel entity)
        {
            if (_currentUserInfo == null)
                return ErrorTypes.NoAuthenticated.Because("There is no user log in");

            List<UserScheduleSection> userSections = await _userScheduleSectionRepository.GetAllByUserIdAsync(_currentUserInfo.Id);
            ClassRoomSubject sectionToBeSaved = await _classRoomSubjectRepository.GetByIdAsync(entity.ClassRoomSubjectId);

            IEnumerable<ClassRoomSubject> groupSections = userSections.Where(s => s.classRoomSubject.Day == sectionToBeSaved.Day).Select(s => s.classRoomSubject);
            // it's the first section that will be on that day
            if (userSections.Count == 0)
                return await base.SaveAsync(entity);



            foreach (ClassRoomSubject section in groupSections)
            {
                if (!IsNewSectionTimeFrameValid(section, sectionToBeSaved))
                    return ErrorTypes.DateConfilct.Because("You allready have a class in that time section");

            }
                return await base.SaveAsync(entity);
        }

        private bool IsNewSectionTimeFrameValid(ClassRoomSubject sectionAllreadySaved, ClassRoomSubject sectionToBeSaved)
        {
            if (sectionToBeSaved.HourBeging < sectionAllreadySaved.HourFinish && sectionToBeSaved.HourFinish > sectionAllreadySaved.HourBeging) 
                return false;

            return true;
        }
    }
}
