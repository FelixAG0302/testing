using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using testing.Domain.Entities;
using testing.Domain.Repositories.Persistance;
using testing.Infraestructure.Core;

namespace testing.Infraestructure.Repositries
{
    public class UserDegreeRepository : BaseRepository<UserDegree>, IUserDegreeRepository
    {
        private readonly AplicationContext _context;

        public UserDegreeRepository(AplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserDegree> GetAllByUserIdAsync(string id)
        {
            return await _context.UserDegrees.FirstOrDefaultAsync(u => u.UserId == id);
        }
    }
}
