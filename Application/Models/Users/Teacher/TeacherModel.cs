using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Application.Models.TeacherSubject;

namespace testing.Application.Models.Users.Teacher
{
    public class TeacherModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cedula { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        public bool IsOnVacation { get; set; }
        public IList<TeacherSubjectModel>? Subjects { get; set; }
    }
}
