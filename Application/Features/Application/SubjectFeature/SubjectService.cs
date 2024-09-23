using MapsterMapper;
using testing.Application.Core;
using testing.Application.Features.Application.SubjectFeature.Models;
using testing.Domain.Entities;
using testing.Domain.Repositories.Persistance;

namespace testing.Application.Features.Application.SubjectFeature
{
    public class SubjectService : BaseCompleteService<SubjectModel, SaveSubjectModel, Subject>, ISubjectService
    {
        public SubjectService(ISubjectRepository subjectRepository, IMapper mapper) : base(subjectRepository, mapper)
        {
        }
    }
}
