using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
