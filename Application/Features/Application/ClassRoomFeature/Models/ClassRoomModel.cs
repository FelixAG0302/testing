
using testing.Application.Features.Application.ClassRoomSubjectFeature.Models;

namespace testing.Application.Features.Application.ClassRoomFeature.Models
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
