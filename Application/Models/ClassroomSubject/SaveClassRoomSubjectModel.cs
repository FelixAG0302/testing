namespace testing.Application.Models.ClassroomSubject
{
    public class SaveClassRoomSubjectModel
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int ClassRoomId { get; set; }
        public int TeacherId { get; set; }
        public TimeSpan HourBegin { get; set; }
        public TimeSpan HourFinish { get; set; }
        public int Day { get; set; }
    }
}
