using Infraestructure.Context;
using testing.Domain.Entities;
using testing.Domain.Repositories.Persistance;
using testing.Infraestructure.Core;

namespace testing.Infraestructure.Repositries
{
    public class TeacherSubjectRepository : BaseRepository<TeacherSubject>, ITeacherSubjectRepository
    {
        private readonly AplicationContext _context;

        public TeacherSubjectRepository(AplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
