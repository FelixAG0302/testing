using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using testing.Domain.Entities;
using testing.Domain.Repositories.Persistance;
using testing.Infraestructure.Core;

namespace testing.Infraestructure.Repositries
{
    public class ClassRoomSubjectRepository : BaseCompleteRepository<ClassRoomSubject>, IClassRoomSubjectRepository
    {
        private readonly AplicationContext _context;

        public ClassRoomSubjectRepository(AplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ClassRoomSubject>> Filter(int degreeId, string TeacherId, string ClassRoomCode, int Day)
        {
            IEnumerable<ClassRoomSubject> query = _context.ClassRoomSubject;

            if (degreeId > 0)
            {
                query = query.Where(c => c.degreeId == degreeId);
            }
            if (TeacherId != default)
            {
                query = query.Where(c => c.TeacherId == TeacherId);
            }
            if (ClassRoomCode != null)
            {
                query = query.Where(c => c.ClassRoom.Code == ClassRoomCode);
            }
            if (Day > 0)
            {
                query = query.Where(c => c.Day == Day);
            }
            return await Task.FromResult(query.ToList());
        }

        public async Task<List<ClassRoomSubject>> GetAllByUserIdAsync(string id)
        {
            return await _context.ClassRoomSubject.Include(s => s.Subject)
                .Include(c => c.ClassRoom)
                .Include(d => d.degree)
                .Where(c => c.TeacherId == id).ToListAsync();
        }

        public override async Task<bool> UpdateAsync(ClassRoomSubject entity)
        {
            if (!await ExitsAsync(c => c.Id == entity.Id)) return false;

            ClassRoomSubject classRoomSubjectToBeUpdated = await _context.ClassRoomSubject.FindAsync(entity.Id);


            classRoomSubjectToBeUpdated.ClassHours = entity.ClassHours;
            classRoomSubjectToBeUpdated.AmountOfUsers = entity.AmountOfUsers;
            classRoomSubjectToBeUpdated.Day = classRoomSubjectToBeUpdated.Day;
            classRoomSubjectToBeUpdated.ClassRoomId = entity.ClassRoomId;
            classRoomSubjectToBeUpdated.TeacherId = entity.TeacherId;

            return await base.UpdateAsync(classRoomSubjectToBeUpdated);
        }
    }
}
