
using System.ComponentModel.DataAnnotations.Schema;


namespace testing.Domain.Entities
{
   public class TeacherSubject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string TecherId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }

    }
}
