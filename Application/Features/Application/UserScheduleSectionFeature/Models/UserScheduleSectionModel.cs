using System.ComponentModel.DataAnnotations.Schema;
using testing.Domain.Entities;

namespace testing.Application.Features.Application.UserScheduleSectionFeature.Models
{
    public class UserScheduleSectionModel
    {
        public int Id { get; set; }
        public UserSchedule UserSchedule { get; set; }
        public ClassRoomSubject classRoomSubject { get; set; }
    }
}
