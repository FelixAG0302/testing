
using System.ComponentModel.DataAnnotations.Schema;
using testing.Domain.Entities.ContextEntities;


namespace testing.Domain.Entities
{
   public class ClassRoomSubject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "navrchar(4)")]
        public string SectionGroup { get; set; }
        public int SubjectId { get; set; }
        public int ClassRoomId { get; set; }    
        public int DegreeId { get; set; }
        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int AmountOfUsers { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan ClassHours { get; set; }
        [Column(TypeName ="time")]
        public TimeOnly HourBeging { get; set; }
        [Column(TypeName = "time")]
        public TimeOnly HourFinish { get; set; }

        public int Day { get; set; }
        [ForeignKey("Day")]
        public DayOfTheWeek DayOfWeek { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        [ForeignKey("ClassRoomId")]
        public ClassRoom ClassRoom { get; set; }
        [ForeignKey("DegreeId")]
        public Degree Degree { get; set; }

    }
}
