
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using testing.Application.Contracts.Persistance;
using testing.Application.Core;
using testing.Application.Dtos.Indentity.Account;
using testing.Application.Models.UserSchedule;
using testing.Application.Models.UserScheduleSection;
using testing.Application.Utils.SessionHandler;
using testing.Domain.Entities;
using testing.Domain.Model;
using testing.Domain.Repositories.Persistance;
using testing.Domain.Settings;
using testing.Identity.Enums;

namespace testing.Application.Services.Persistance
{
    public class UserScheduleService : BaseCompleteService<UserScheduleModel, SaveUserScheduleModel, UserSchedule>, IUserScheduleService
    {
        private readonly IUserScheduleRepository _userScheduleRepository;
        private readonly IUserScheduleSectionService _userScheduleSectionService;
        private readonly IMapper _mapper;
        private readonly SessionKeys _sessionkeys;
        private readonly AuthenticationResponce _currentUserInfoInSession;
        public UserScheduleService(IUserScheduleRepository userScheduleRepository, IMapper mapper, IUserScheduleSectionService userScheduleSectionService, ISession session, IOptions<SessionKeys> sessionKeys) : base(userScheduleRepository, mapper)
        {
            _userScheduleRepository = userScheduleRepository;
            _mapper = mapper;
            _userScheduleSectionService = userScheduleSectionService;
            _sessionkeys = sessionKeys.Value;
            _currentUserInfoInSession = session.Get<AuthenticationResponce>(_sessionkeys.UserKey);
        }

        public async Task<Result<List<UserScheduleModel>>> GetClientUsersSchedules()
        {
            Result<List<UserScheduleModel>> result = new();

            if (_currentUserInfoInSession == null)
            {
                result.IsSuccess = false;
                result.Message = "There is no current user authenticated";
                return result;
            }
            // Validate user rol and credentials
            if (_currentUserInfoInSession.Roles.Any(u => u == nameof(Roles.Client)))
            {
                result.IsSuccess = false;
                result.Message = "Only client users can access this resource";
                return result;
            }
            try
            {
              

                List<UserSchedule> userSchedules = await _userScheduleRepository.GetAllByUserIdAsync(_currentUserInfoInSession.Id);
                List<UserScheduleModel> userSchedulesToBeReturne = _mapper.Map<List<UserScheduleModel>>(userSchedules);
                result.Data = userSchedulesToBeReturne;
                result.Message = "The process was succesfull";
                return result;
            }
            catch
            {
                result.IsSuccess = false;
                result.Message = "A critical error has ocurred";
                return result;

            }
        }

        public async override Task<Result> SaveAsync(SaveUserScheduleModel entity)
        {
            //validations 

            Result result = await base.SaveAsync(entity);

            if (!result.IsSuccess) return result;

            return result;

        }

        //FINISH :B
        //Osker
    }
}
