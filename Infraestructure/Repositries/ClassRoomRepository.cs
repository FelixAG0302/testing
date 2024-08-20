using Infraestructure.Context;
using Infraestructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Domain.Entities;
using testing.Domain.Repositories;

namespace testing.Infraestructure.Repositries
{
    public class ClassRoomRepository : BaseCompleteRepository<ClassRoom>, IClassRoomRepository
    {
        public ClassRoomRepository(AplicationContext context) : base(context)
        {
        }
    }
}
