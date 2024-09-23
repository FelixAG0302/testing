using testing.Application.Core;
using testing.Application.Features.Application.SubjectFeature.Models;


namespace testing.Application.Features.Application.SubjectFeature
{
    public interface ISubjectService : IBaseCompleteService<SubjectModel, SaveSubjectModel>
    {
    }
}
