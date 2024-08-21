
using System.ComponentModel.DataAnnotations.Schema;


namespace testing.Domain.Entities
{
   public class ClassRoomSubject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int ClassRoomId { get; set; }       
        public int TeacherId { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan HourBegin { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan HourFinish { get; set; }
        public int Day { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        [ForeignKey("ClassRoomId")]
        public ClassRoom ClassRoom { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }
    }
}
