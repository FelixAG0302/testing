
using testing.Domain.Core;
using testing.Domain.Entities;
using testing.Domain.Utils;

namespace testing.Domain.Repositories
{
    public interface IClassRoomSubjectRepository : IBaseCompleteRepository<ClassRoomSubject> , IGetElementsForUserAsync<ClassRoomSubject>
    {
        Task<List<ClassRoomSubject>> Filter(int degreeId, string TeacherId, string ClassRoomCode, int Day);
    }
}
