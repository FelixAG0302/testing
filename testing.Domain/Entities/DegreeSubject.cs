
using System.ComponentModel.DataAnnotations.Schema;


namespace testing.Domain.Entities
{
    public class DegreeSubject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int DegreeId {  get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        [ForeignKey("DegreeId")]
        public Degree Degree { get; set; }
    }
}
