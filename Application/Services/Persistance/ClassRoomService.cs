using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Application.Contracts.Persistance;
using testing.Application.Core;
using testing.Application.Models.ClassRoom;
using testing.Domain.Entities;
using testing.Domain.Repositories;

namespace testing.Application.Services.Persistance
{
    public class ClassRoomService : BaseCompleteService<ClassRoomModel, SaveClassRoomModel, ClassRoom>, IClassRoomService
    {
        private readonly IClassRoomRepository _classRoomRepository;
        public ClassRoomService(IClassRoomRepository classRoomRepository, IMapper mapper) : base(classRoomRepository, mapper)
        {
            _classRoomRepository = classRoomRepository;
        }
   


    }
}
