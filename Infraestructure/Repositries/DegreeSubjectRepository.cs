using Infraestructure.Context;
using testing.Domain.Entities;
using testing.Domain.Repositories.Persistance;
using testing.Infraestructure.Core;

namespace testing.Infraestructure.Repositries
{
    public class DegreeSubjectRepository : BaseRepository<DegreeSubject>, IDegreeSubjectRepository
    {
        private readonly AplicationContext _context;

        public DegreeSubjectRepository(AplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
