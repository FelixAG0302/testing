using System.ComponentModel.DataAnnotations.Schema;
using testing.Application.Models.Subject;

namespace testing.Application.Models.TeacherSubject
{
    public class SaveTeacherSubjectModel
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int TecherId { get; set; }
        
    }
}
