using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Application.Models.Subject;
using testing.Application.Models.Users.Teacher;

namespace testing.Application.Models.TeacherSubject
{
    public class TeacherSubjectModel
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int TecherId { get; set; }
        public SubjectModel Subject { get; set; }
        public TeacherModel Teacher { get; set; }
    }
}
