
using testing.Domain.Core;

namespace testing.Domain.Entities
{
    public class Degree : BaseEntity
    {
        public IList<DegreeSubject> DegreeSubjects { get; set; }
    }
}
