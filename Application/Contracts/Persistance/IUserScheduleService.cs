
using testing.Application.Core;
using testing.Application.Models.UserSchedule;

namespace testing.Application.Contracts.Persistance
{
    public interface IUserScheduleService : IBaseCompleteService<UserScheduleModel, SaveUserScheduleModel>
    {
        Task<Result<List<UserScheduleModel>>> GetClientUsersSchedules();
    }
}
