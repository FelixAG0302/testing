using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Application.Core;
using testing.Application.Models.UserSchedule;

namespace testing.Application.Contracts.Persistance
{
    public interface IUserScheduleService : IBaseCompleteService<UserScheduleModel, SaveUserScheduleModel>
    {
    }
}
