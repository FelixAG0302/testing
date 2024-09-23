using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using testing.Application.Core;
using testing.Application.Extensions;
using testing.Application.Features.Application.UserScheduleFeature.Model;
using testing.Application.Utils.Enums;
using testing.Application.Utils.SessionHandler;
using testing.Domain.Entities;
using testing.Domain.Model;
using testing.Domain.Repositories.Persistance;
using testing.Domain.Settings;
using testing.Identity.Enums;

namespace testing.Application.Features.Application.UserScheduleFeature
{
    public class UserScheduleService : BaseCompleteService<UserScheduleModel, SaveUserScheduleModel, UserSchedule>, IUserScheduleService
    {
        private readonly IUserScheduleRepository _userScheduleRepository;
        private readonly IMapper _mapper;
        private readonly SessionKeys _sessionkeys;
        private readonly AuthenticationResponce _currentUserInfoInSession;
        public UserScheduleService(IUserScheduleRepository userScheduleRepository, IMapper mapper, ISession session, IOptions<SessionKeys> sessionKeys) : base(userScheduleRepository, mapper)
        {
            _userScheduleRepository = userScheduleRepository;
            _mapper = mapper;
            _sessionkeys = sessionKeys.Value;
            _currentUserInfoInSession = session.Get<AuthenticationResponce>(_sessionkeys.UserKey);
        }

        public async Task<Result<List<UserScheduleModel>>> GetClientUsersSchedules()
        {
            if (_currentUserInfoInSession == null)
                return ErrorTypes.NoAuthenticated.Because("There is no current user authenticated");

            // Validate user rol and credentials
            if (_currentUserInfoInSession.Roles.Any(u => u == nameof(Roles.Client)))
                return ErrorTypes.NoAuthorize.Because("Only client users can access this resource");

            try
            {
                List<UserSchedule> userSchedules = await _userScheduleRepository.GetAllByUserIdAsync(_currentUserInfoInSession.Id);

                return _mapper.Map<List<UserScheduleModel>>(userSchedules);
            }
            catch
            {
                return ErrorTypes.Exceptions.Because("A critical error has ocurred");
            }
        }



        //FINISH :B
        //Osker
    }
}
