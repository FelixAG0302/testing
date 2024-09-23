using testing.Application.Core;
using testing.Application.Features.Application.UserScheduleFeature.Model;


namespace testing.Application.Features.Application.UserScheduleFeature
{
    public interface IUserScheduleService : IBaseCompleteService<UserScheduleModel, SaveUserScheduleModel>
    {
        Task<Result<List<UserScheduleModel>>> GetClientUsersSchedules();
    }
}
