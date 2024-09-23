using testing.Application.Features.Application.ClassRoomSubjectFeature.Models;
using testing.Application.Features.Application.TeacherSubjectFeature.Models;


namespace testing.Application.Features.Application.SubjectFeature.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<TeacherSubjectModel>? TeacherSubjects { get; set; }
        public IList<ClassRoomSubjectModel>? ClassRoomSubjects { get; set; }
    }
}
