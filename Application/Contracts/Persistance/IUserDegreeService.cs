
using testing.Application.Core;
using testing.Application.Models.UserDegree;

namespace testing.Application.Contracts.Persistance
{
    internal interface IUserDegreeService : IBaseService<SaveUserDegreeModel>
    {
        internal Task<Result<UserDegreeModel>> GetByUserId(string userId);
    }
}
