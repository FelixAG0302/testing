using testing.Application.Features.Application.DegreeSubjectFeature.Models;


namespace testing.Application.Features.Application.DegreeFeature.Models
{
    public class DegreeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BaseAmountOfCredits { get; set; }
        public IList<DegreeSubjectModel> DegreeSubjects { get; set; }
    }
}
