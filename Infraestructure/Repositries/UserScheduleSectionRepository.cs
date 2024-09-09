using Infraestructure.Context;
using testing.Domain.Entities;
using testing.Domain.Repositories.Persistance;
using testing.Infraestructure.Core;

namespace testing.Infraestructure.Repositries
{
    public class UserScheduleSectionRepository : BaseRepository<UserScheduleSection>, IUserScheduleSectionRepository
    {
        private readonly AplicationContext _context;

        public UserScheduleSectionRepository(AplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
