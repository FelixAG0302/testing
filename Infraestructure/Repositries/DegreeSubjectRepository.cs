using Infraestructure.Context;
using Infraestructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Domain.Entities;
using testing.Domain.Repositories.Persistance;

namespace testing.Infraestructure.Repositries
{
    public class DegreeSubjectRepository : BaseRepository<DegreeSubject>, IDegreeSubjectRepository
    {
        public DegreeSubjectRepository(AplicationContext context) : base(context)
        {
        }
    }
}
