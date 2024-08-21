
using System.ComponentModel.DataAnnotations.Schema;


namespace testing.Domain.Entities
{
   public class TeacherSubject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int TecherId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        [ForeignKey("TecherId")]
        public Teacher Teacher { get; set; }
    }
}
