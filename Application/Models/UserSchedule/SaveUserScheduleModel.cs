using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Domain.Entities;

namespace testing.Application.Models.UserSchedule
{
    public class SaveUserScheduleModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ClassRoomSubjectId { get; set; }
    }
}
