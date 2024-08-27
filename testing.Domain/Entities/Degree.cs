
using testing.Domain.Core;

namespace testing.Domain.Entities
{
    public class Degree : BaseEntity
    {
        public int BaseAmountOfCredits { get; set; }
        public IList<DegreeSubject> DegreeSubjects { get; set; }
    }
}
