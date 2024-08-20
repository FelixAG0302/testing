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
    public class ClassRoomSubjectRepository : BaseRepository<ClassRoomSubject>, IClassRoomSubjectRepository
    {
        public ClassRoomSubjectRepository(AplicationContext context) : base(context)
        {
        }
    }
}
