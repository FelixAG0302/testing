
using System.ComponentModel.DataAnnotations.Schema;


namespace testing.Domain.Entities
{
   public class ClassRoomSubject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "navrchar(3)")]
        public string Code { get; set; }
        public int SubjectId { get; set; }
        public int ClassRoomId { get; set; }    
        public int degreeId { get; set; }
        public string TeacherId { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan ClassHours { get; set; }
        public int Day { get; set; }
        public int AmountOfUsers { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        [ForeignKey("ClassRoomId")]
        public ClassRoom ClassRoom { get; set; }
        public Degree degree { get; set; }

    }
}
