using testing.Application.Core;
using testing.Application.Features.Application.DegreeFeature.Models;

namespace testing.Application.Features.Application.DegreeFeature
{
    public interface IDegreeService : IBaseCompleteService<DegreeModel, SaveDegreeModel>
    {
    }
}
