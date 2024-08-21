using Infraestructure.Context;
using Infraestructure.Core;
using testing.Domain.Entities;
using testing.Domain.Repositories;

namespace testing.Infraestructure.Repositries
{
    public class ClassRoomSubjectRepository : BaseCompleteRepository<ClassRoomSubject>, IClassRoomSubjectRepository
    {
        private readonly AplicationContext _context;

        public ClassRoomSubjectRepository(AplicationContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<bool> UpdateAsync(ClassRoomSubject entity)
        {
            if (!await ExitsAsync(c => c.Id == entity.Id)) return false;

            ClassRoomSubject classRoomSubjectToBeUpdated = await _context.ClassRoomSubject.FindAsync(entity.Id);

            classRoomSubjectToBeUpdated.HourFinish = entity.HourFinish;
            classRoomSubjectToBeUpdated.HourBegin = entity.HourBegin;
            classRoomSubjectToBeUpdated.Day = classRoomSubjectToBeUpdated.Day;
            classRoomSubjectToBeUpdated.SubjectId = entity.SubjectId;
            classRoomSubjectToBeUpdated.ClassRoomId = entity.ClassRoomId;
            classRoomSubjectToBeUpdated.Teacher = entity.Teacher;
            
            return await base.UpdateAsync(classRoomSubjectToBeUpdated);
        }
    }
}
