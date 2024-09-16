

using testing.Domain.Core;
using testing.Domain.Entities;
using testing.Domain.Utils;

namespace testing.Domain.Repositories.Persistance
{
    public interface IUserDegreeRepository : IBaseRepository<UserDegree> 
    {
        Task<UserDegree> GetAllByUserIdAsync(string id);
    }
}
