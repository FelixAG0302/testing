using MapsterMapper;
using testing.Application.Core;
using testing.Application.Extensions;
using testing.Application.Features.Application.UserDegreeFeature.Model;
using testing.Application.Utils.Enums;
using testing.Domain.Entities;
using testing.Domain.Repositories.Persistance;

namespace testing.Application.Features.Application.UserDegreeFeature
{
    internal class UserDegreeService : BaseService<SaveUserDegreeModel, UserDegree>, IUserDegreeService
    {
        private readonly IUserDegreeRepository _userDegreeRepository;
        private readonly IMapper _mapper;

        public UserDegreeService(IUserDegreeRepository userDegreeRepository, IMapper mapper) : base(userDegreeRepository, mapper)
        {
            _userDegreeRepository = userDegreeRepository;
            _mapper = mapper;
        }

        public async Task<Result<UserDegreeModel>> GetByUserId(string userId)
        {
            try
            {
                if (userId == null)
                    return ErrorTypes.Validation.Because("the user id cant be null");

                UserDegree userDegreeGetted = await _userDegreeRepository.GetAllByUserIdAsync(userId);

                if (userDegreeGetted == null)
                    return ErrorTypes.OperationError.Because("The user's degree was not found in the database");

                return _mapper.Map<UserDegreeModel>(userDegreeGetted);
            }
            catch
            {
                return ErrorTypes.Exceptions.Because("Critical error while getting the user's degree");
            }
        }
    }
}
