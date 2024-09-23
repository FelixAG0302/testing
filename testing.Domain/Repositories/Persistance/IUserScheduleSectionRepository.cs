using testing.Domain.Core;
using testing.Domain.Entities;
using testing.Domain.Utils;

namespace testing.Domain.Repositories.Persistance
{
    public interface IUserScheduleSectionRepository : IBaseRepository<UserScheduleSection>, IGetElementsForUserAsync<UserScheduleSection>
    {
    }
}
