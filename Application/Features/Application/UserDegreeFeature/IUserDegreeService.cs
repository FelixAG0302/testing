using testing.Application.Core;
using testing.Application.Features.Application.UserDegreeFeature.Model;


namespace testing.Application.Features.Application.UserDegreeFeature
{
    internal interface IUserDegreeService : IBaseService<SaveUserDegreeModel>
    {
        internal Task<Result<UserDegreeModel>> GetByUserId(string userId);
    }
}
