using Infraestructure.Context;
using Infraestructure.Core;
using testing.Domain.Entities;
using testing.Domain.Repositories;

namespace testing.Infraestructure.Repositries
{
    public class TeacherSubjectRepository : BaseRepository<TeacherSubject>, ITeacherSubjectRepository
    {
        public TeacherSubjectRepository(AplicationContext context) : base(context)
        {

        }
    }
}
