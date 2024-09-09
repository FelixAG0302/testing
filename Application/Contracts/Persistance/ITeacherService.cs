
using testing.Application.Core;
using testing.Application.Models.Users.Teacher;

namespace testing.Application.Contracts.Persistance
{
    public interface ITeacherService : IBaseCompleteService<TeacherModel, SaveTeacherModel>
    {
    }
}
