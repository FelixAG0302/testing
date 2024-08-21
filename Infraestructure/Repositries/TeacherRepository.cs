using Infraestructure.Context;
using Infraestructure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using testing.Domain.Entities;
using testing.Domain.Repositories;

namespace testing.Infraestructure.Repositries
{
    public class TeacherRepository : BaseCompleteRepository<Teacher>, ITeacherRepository
    {
        private readonly AplicationContext _context;

        public TeacherRepository(AplicationContext context) : base(context)
        {
            _context = context;
        }

        public override Task<bool> DeleteAsync(int Id)
        {
            return base.DeleteAsync(Id);
        }

        public override async Task<List<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.Include(s => s.Subjects).ToListAsync();
        }

        public override async Task<Teacher> GetByIdAsync(int id)
        {
            return await _context.Teachers.Include(s => s.Subjects).FirstOrDefaultAsync();
        }

        public override Task<bool> SaveAsync(Teacher entity)
        {
            return base.SaveAsync(entity);
        }

        public override async Task<bool> UpdateAsync(Teacher entity)
        {
            try
            {
                if (!await base.ExitsAsync(i => i.Id == entity.Id)) return false;

                Teacher teacherToBeUpdate = await _context.Teachers.FindAsync(entity.Id);

                teacherToBeUpdate.FirstName = entity.FirstName;
                teacherToBeUpdate.LastName = entity.LastName;
                teacherToBeUpdate.Cedula = entity.Cedula;
                teacherToBeUpdate.Phone = entity.Phone;
                teacherToBeUpdate.Salary = entity.Salary;
                teacherToBeUpdate.IsOnVacation = entity.IsOnVacation;
                return await base.UpdateAsync(teacherToBeUpdate);
            }
            catch
            {
                return false;
            }
        }
    }
}
