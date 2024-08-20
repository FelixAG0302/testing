using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Application.Core;
using testing.Application.Models.Teacher;

namespace testing.Application.Contracts.Persistance
{
    public interface ITeacherService : IBaseCompleteService<TeacherModel, SaveTeacherModel>
    {
    }
}
