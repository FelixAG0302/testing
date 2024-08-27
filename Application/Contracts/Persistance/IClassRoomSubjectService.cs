
using testing.Application.Core;
using testing.Application.Models.ClassroomSubject;
using testing.Domain.Entities;

namespace testing.Application.Contracts.Persistance
{
    public interface IClassRoomSubjectService : IBaseService<SaveClassRoomSubjectModel>
    {
        Task<Result<List<ClassRoomSubject>>> FilterAsync(FilterClassRoomSubjectModel filterModel);
        Task<Result<List<ClassRoomSubjectModel>>> GetTeachesSectionAsync();
    }
}
