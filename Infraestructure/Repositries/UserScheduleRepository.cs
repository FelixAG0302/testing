using Infraestructure.Context;
using Infraestructure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Domain.Entities;
using testing.Domain.Repositories;

namespace testing.Infraestructure.Repositries
{
    public class UserScheduleRepository : BaseCompleteRepository<UserSchedule>, IUserScheduleRepository
    {
        private readonly AplicationContext _context;

        public UserScheduleRepository(AplicationContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<UserSchedule>> GetAllAsync()
        {
            return await _context.Schedules.Include(u => u.ClassRoomSubject).ToListAsync();
        }

        public async Task<List<UserSchedule>> GetAllByUserIdAsync(string id)
        {
            return await _context.Schedules.Include(s => s.ClassRoomSubject).Where(s => s.UserId == id).ToListAsync();
        }

        public override async Task<UserSchedule> GetByIdAsync(int id)
        {

            return await _context.Schedules.Include(u => u.ClassRoomSubject).Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public override async Task<bool> UpdateAsync(UserSchedule entity)
        {
            try
            {
                if (!await base.ExitsAsync(u => u.Id == entity.Id)) return false;

                UserSchedule userScheduleToBeUpdated = await _context.Schedules.FindAsync(entity.Id);

                userScheduleToBeUpdated.ClassRoomSubject = entity.ClassRoomSubject;
                return await base.UpdateAsync(userScheduleToBeUpdated);
            }
            catch
            {
                return false;
            }
        }
    }
}
