using AutoMapper;
using testing.Application.Contracts.Persistance;
using testing.Application.Core;
using testing.Application.Models.UserScheduleSection;
using testing.Domain.Entities;
using testing.Domain.Repositories;

namespace testing.Application.Services.Persistance
{
    public class UserScheduleSectionService : BaseService<SaveUserScheduleSectionModel, UserScheduleSection>, IUserScheduleSectionService
    {
        private readonly IUserScheduleSectionRepository _userScheduleSectionRepository;
        private readonly IMapper _mapper;

        public UserScheduleSectionService(IUserScheduleSectionRepository userScheduleSectionRepository, IMapper mapper) : base(userScheduleSectionRepository, mapper)
        {
            _userScheduleSectionRepository = userScheduleSectionRepository;
            _mapper = mapper;
        }
    }
}
