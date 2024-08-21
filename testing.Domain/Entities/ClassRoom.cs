
using testing.Domain.Core;

namespace testing.Domain.Entities
{
    public class ClassRoom : BaseEntity
    {

        public string Code { get; set; }
        public IList<ClassRoomSubject> ClassRoomSubjects { get; set; }  
    }
}
