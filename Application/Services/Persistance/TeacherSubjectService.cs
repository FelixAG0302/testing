using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Application.Contracts.Persistance;
using testing.Application.Core;
using testing.Application.Models.Teacher;
using testing.Application.Models.TeacherSubject;
using testing.Domain.Core;
using testing.Domain.Entities;
using testing.Domain.Repositories;

namespace testing.Application.Services.Persistance
{
    public class TeacherSubjectService : BaseService<SaveTeacherSubjectModel, TeacherSubject>, ITeacherSubjectService
    {
        private readonly ITeacherSubjectRepository _teacherSubjectRepository;
        private readonly IMapper _mapper;

        public TeacherSubjectService(ITeacherSubjectRepository teacherSubjectRepository, IMapper mapper) : base(teacherSubjectRepository, mapper)
        {
            _teacherSubjectRepository = teacherSubjectRepository;
            _mapper = mapper;
        }
    }
}
