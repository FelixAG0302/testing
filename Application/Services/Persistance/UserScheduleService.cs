using AutoMapper;
using testing.Application.Contracts.Persistance;
using testing.Application.Core;
using testing.Application.Models.UserSchedule;
using testing.Domain.Entities;
using testing.Domain.Repositories;

namespace testing.Application.Services.Persistance
{
    public class UserScheduleService: BaseCompleteService<UserScheduleModel, SaveUserScheduleModel, UserSchedule>, IUserScheduleService
    {
        private readonly IUserScheduleRepository _userScheduleRepository;
        private readonly IMapper _mapper;

        public UserScheduleService(IUserScheduleRepository userScheduleRepository, IMapper mapper) : base(userScheduleRepository, mapper)
        {
            _userScheduleRepository = userScheduleRepository;
            _mapper = mapper;
        }
        //FINISH :B
        //Osker
    }
}
