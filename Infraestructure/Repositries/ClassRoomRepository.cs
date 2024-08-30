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
    public class ClassRoomRepository : BaseCompleteRepository<ClassRoom>, IClassRoomRepository
    {
        private readonly AplicationContext _context;

        public ClassRoomRepository(AplicationContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<bool> UpdateAsync(ClassRoom entity)
        {
            if (!await ExitsAsync(c => c.Id == entity.Id)) return false;

            ClassRoom classRoomToBeUpdated = await _context.ClassRoom.FindAsync(entity.Id);

            classRoomToBeUpdated.Name = entity.Name;
            classRoomToBeUpdated.Description = entity.Description;
            classRoomToBeUpdated.Code = entity.Code;

            return await base.UpdateAsync(classRoomToBeUpdated);
        }
    }
}
