using testing.Application.Features.Application.DegreeFeature.Models;
using testing.Application.Features.Application.SubjectFeature.Models;


namespace testing.Application.Features.Application.DegreeSubjectFeature.Models
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
