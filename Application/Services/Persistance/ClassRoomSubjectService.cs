using AutoMapper;
using testing.Application.Contracts.Persistance;
using testing.Application.Core;
using testing.Application.Models.ClassroomSubject;
using testing.Domain.Entities;
using testing.Domain.Repositories;

namespace testing.Application.Services.Persistance
{
    public class ClassRoomSubjectService : BaseService<SaveClassRoomSubjectModel, ClassRoomSubject>, IClassRoomSubjectService
    {
        private readonly IClassRoomSubjectRepository _classRoomSubjectRepository;
        public ClassRoomSubjectService(IClassRoomSubjectRepository classRoomSubjectRepository, IMapper mapper) : base(classRoomSubjectRepository, mapper)
        {
            _classRoomSubjectRepository = classRoomSubjectRepository;
        }
    }
}
