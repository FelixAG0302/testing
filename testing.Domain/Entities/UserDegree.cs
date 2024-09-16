using System.ComponentModel.DataAnnotations.Schema;


namespace testing.Domain.Entities
{
    public class UserDegree
    {
        public string UserId { get; set; }
        public int DegreeId { get; set; }
        [ForeignKey("DegreeId")]
        public Degree Degree { get; set; }
    }
}
