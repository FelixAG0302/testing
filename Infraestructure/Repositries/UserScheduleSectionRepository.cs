using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<UserScheduleSection>> GetAllByUserIdAsync(string id)
        {
            return await _context.ScheduleSections.AsSplitQuery()
                .AsNoTracking().Include(s => s.classRoomSubject).Where(s => s.UserSchedule.UserId == id).ToListAsync();
        }
    }
}
