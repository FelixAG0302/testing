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
    public class SubjectRepository : BaseCompleteRepository<Subject>, ISubjectRepository
    {
        private readonly AplicationContext _context;

        public SubjectRepository(AplicationContext context) : base(context)
        {
            _context = context;
        }

        public override Task<bool> DeleteAsync(int Id)
        {
            return base.DeleteAsync(Id);
        }

        public override async Task<List<Subject>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }

  

        public override async Task<bool> UpdateAsync(Subject entity)
        {
            try
            {
                if (!await base.ExitsAsync(i => i.Id == entity.Id)) return false;
                
                Subject subjectToBeUpdate = await _context.Subject.FindAsync(entity.Id);

                subjectToBeUpdate.Description = entity.Description;

                return await base.UpdateAsync(entity);
            }
            catch
            {
                return false;
            }
            
        }
    }
}
