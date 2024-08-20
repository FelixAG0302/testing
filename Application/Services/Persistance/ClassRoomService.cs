using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Application.Contracts.Persistance;
using testing.Application.Core;
using testing.Application.Models.ClassRoom;
using testing.Domain.Entities;
using testing.Domain.Repositories;

namespace testing.Application.Services.Persistance
{
    public class ClassRoomService : IClassRoomService
    {
        private readonly IClassRoomRepository _classRoomRepository;
        public ClassRoomService(IClassRoomRepository classRoomRepository)
        {
            _classRoomRepository = classRoomRepository;
        }
  
        public async Task<Result<List<ClassRoomModel>>> GetAllAsync()
        {
            Result<List<ClassRoomModel>> result = new();
            try
            {
                List<ClassRoom> entitiesGetted = await _classRoomRepository.GetAllAsync();
                result.Data = entitiesGetted.Select(c => new ClassRoomModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code,
                    Description = c.Description,
                    ClassRoomSubjects = c.ClassRoomSubjects.Select(c => new Models.SubEntitie.ClassRoomSubjectModel
                    {
                        
                    }).ToList()
                }).ToList();

                result.Message = "Success getting the classroom's ";
                return result;
            }
            catch
            {
                result.IsSuccess = false;
                result.Message = "Critical error getting the classrooms ";
                return result;
            }
        }

        public Task<Result<ClassRoomModel>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> SaveAsync(SaveClassRoomModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateAsync(SaveClassRoomModel entity)
        {
            throw new NotImplementedException();
        }     
        public Task<Result> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
