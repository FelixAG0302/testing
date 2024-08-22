using AutoMapper;
using testing.Application.Contracts.Persistance;
using testing.Application.Core;
using testing.Application.Models.Teacher;
using testing.Domain.Entities;
using testing.Domain.Repositories;

namespace testing.Application.Services.Persistance
{
    public class TeacherService: BaseCompleteService<TeacherModel, SaveTeacherModel, Teacher>, ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper) : base (teacherRepository, mapper)
        {
            _teacherRepository = teacherRepository;
        }
    }
}
