using testing.Application.Core;
using testing.Application.Features.Application.ClassRoomSubjectFeature.Models;

namespace testing.Application.Features.Application.ClassRoomSubjectFeature
{
    public interface IClassRoomSubjectService : IBaseService<SaveClassRoomSubjectModel>
    {
        Task<Result<List<ClassRoomSubjectModel>>> FilterAsync(FilterClassRoomSubjectModel filterModel);
        Task<Result<List<ClassRoomSubjectModel>>> GetTeachesSectionAsync();
    }
}
