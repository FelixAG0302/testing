using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Application.Models.DegreeSubject;
using testing.Application.Models.TeacherSubject;
using testing.Domain.Entities;

namespace testing.Application.Models.Subject
{
    public class SubjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<DegreeSubjectModel>? DegreeSubjects { get; set; }
        public IList<TeacherSubjectModel>? TeacherSubjects { get; set; }
        public IList<ClassRoomSubject>? ClassRoomSubjects { get; set; }
    }
}
