using System.ComponentModel.DataAnnotations.Schema;
using testing.Application.Models.ClassRoom;
using testing.Application.Models.Subject;
using testing.Application.Models.Users.Teacher;

namespace testing.Application.Models.ClassroomSubject
{
    public class ClassRoomSubjectModel
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int ClassRoomId { get; set; }
        public int TeacherId { get; set; }
        public TimeSpan HourBegin { get; set; }
        public TimeSpan HourFinish { get; set; }
        public int Day { get; set; }
        public SubjectModel Subject { get; set; }
        public ClassRoomModel ClassRoom { get; set; }
        public TeacherModel Teacher { get; set; }
    }
}
