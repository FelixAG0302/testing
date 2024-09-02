using testing.Domain.Core;
using testing.Domain.Entities;
using testing.Domain.Utils;

namespace testing.Domain.Repositories.Persistance
{
    public interface IClassRoomSubjectRepository : IBaseCompleteRepository<ClassRoomSubject>, IGetElementsForUserAsync<ClassRoomSubject>
    {
        Task<List<ClassRoomSubject>> Filter(int degreeId, string TeacherId, string ClassRoomCode, int Day);

    }
}
