using System.ComponentModel.DataAnnotations.Schema;

namespace testing.Application.Models.DegreeSubject
{
    public class SaveDegreeSubjectModel
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int DegreeId { get; set; }
    }
}
