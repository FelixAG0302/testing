
using testing.Application.Core;
using testing.Application.Models.Degree;

namespace testing.Application.Contracts.Persistance
{
    public interface IDegreeService : IBaseCompleteService<DegreeModel, SaveDegreeModel>
    {
    }
}
