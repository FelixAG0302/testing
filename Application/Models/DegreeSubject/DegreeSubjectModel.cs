using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Application.Models.Degree;
using testing.Application.Models.Subject;

namespace testing.Application.Models.DegreeSubject
{
    public class DegreeSubjectModel
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int DegreeId { get; set; }
        public SubjectModel Subject { get; set; }
        public DegreeModel Degree { get; set; }
    }
}
