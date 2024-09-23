
using MapsterMapper;
using testing.Application.Core;
using testing.Application.Features.Application.TeacherSubjectFeature.Models;
using testing.Domain.Entities;
using testing.Domain.Repositories.Persistance;

namespace testing.Application.Features.Application.TeacherSubjectFeature
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
