using testing.Application.Models.ClassroomSubject;

namespace testing.Application.Models.ClassRoom
{
    public class ClassRoomModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public List<ClassRoomSubjectModel> ClassRoomSubjects { get; set; }
    }
}
