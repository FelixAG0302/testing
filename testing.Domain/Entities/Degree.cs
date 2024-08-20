using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Domain.Core;

namespace testing.Domain.Entities
{
    public class Degree : BaseEntity
    {
      
        public IList<DegreeSubject> DegreeSubjects { get; set; }
    }
}
