
using testing.Application.Core;
using testing.Application.Models.ClassroomSubject;

namespace testing.Application.Contracts.Persistance
{
    public interface IClassRoomSubjectService : IBaseService<SaveClassRoomSubjectModel>
    {
        Task<Result<List<ClassRoomSubjectModel>>> FilterAsync(FilterClassRoomSubjectModel filterModel);
        Task<Result<List<ClassRoomSubjectModel>>> GetTeachesSectionAsync();
    }
}
