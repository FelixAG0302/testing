
using System.ComponentModel.DataAnnotations.Schema;


namespace testing.Domain.Entities
{
    public class Teacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cedula {  get; set; }
        public string Phone { get; set; }
        [Column(TypeName = "Decimal(18,2)")]
        public decimal Salary { get; set; }
        public bool IsOnVacation { get; set; }


        public IList<TeacherSubject>? Subjects { get; set; }
        
    }
}
