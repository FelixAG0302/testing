
using testing.Domain.Core;

namespace testing.Domain.Entities
{
    public class Subject  : BaseEntity
    {

        public IList<DegreeSubject>? DegreeSubjects { get; set; }    
        public IList<TeacherSubject>? TeacherSubjects { get; set; }    
        public IList<ClassRoomSubject>? ClassRoomSubjects { get; set; }    
    }
}
