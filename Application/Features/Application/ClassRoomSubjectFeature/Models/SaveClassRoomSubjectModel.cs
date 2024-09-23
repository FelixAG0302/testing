namespace testing.Application.Features.Application.ClassRoomSubjectFeature.Models
{
    public class SaveClassRoomSubjectModel
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int ClassRoomId { get; set; }
        public int DegreeId { get; set; }
        public string SectionGroup { get; set; }
        public string TeacherId { get; set; }
        public string TeacherName { get; set; }

        public TimeOnly HourBegin { get; set; }
        public TimeOnly HourFinish { get; set; }
        public int Day { get; set; }
    }
}
