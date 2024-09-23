
using MapsterMapper;
using testing.Application.Core;
using testing.Application.Features.Application.DegreeSubjectFeature.Models;
using testing.Domain.Entities;
using testing.Domain.Repositories.Persistance;

namespace testing.Application.Features.Application.DegreeSubjectFeature
{
    public class DegreeSubjectService : BaseService<SaveDegreeSubjectModel, DegreeSubject>, IDegreeSubjectService
    {
        private readonly IDegreeSubjectRepository _degreeSubjectRepository;
        public DegreeSubjectService(IDegreeSubjectRepository degreeSubjectRepository, IMapper mapper) : base(degreeSubjectRepository, mapper)
        {
            _degreeSubjectRepository = degreeSubjectRepository;
        }
    }
}
