
using System.ComponentModel.DataAnnotations.Schema;

namespace testing.Domain.Entities
{
    public class UserScheduleSection
    { 
        public int Id { get; set; } 
        public int UserScheduleId { get; set; }
        public int ClassRoomSubjectId { get; set; }
        [ForeignKey("UserScheduleId")]
        public UserSchedule UserSchedule { get; set; }
        [ForeignKey("ClassRoomSubjectId")]
        public ClassRoomSubject classRoomSubject { get; set; }

    }
}
