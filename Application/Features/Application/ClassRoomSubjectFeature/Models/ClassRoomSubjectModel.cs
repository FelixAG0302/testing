
using testing.Application.Features.Application.ClassRoomFeature.Models;
using testing.Application.Features.Application.DegreeFeature.Models;
using testing.Application.Features.Application.SubjectFeature.Models;

namespace testing.Application.Features.Application.ClassRoomSubjectFeature.Models
{
    public class ClassRoomSubjectModel
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string SectionGroup { get; set; }
        public TimeOnly HourBegin { get; set; }
        public TimeOnly HourFinish { get; set; }
        public int Day { get; set; }
        public string TeacherName { get; set; }
        public string TecherId { get; set; }

        public SubjectModel Subject { get; set; }
        public ClassRoomModel ClassRoom { get; set; }
        public DegreeModel Degree { get; set; }
    }
}
