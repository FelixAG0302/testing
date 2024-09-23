using System.ComponentModel.DataAnnotations.Schema;
using testing.Domain.Entities;

namespace testing.Application.Features.Application.UserScheduleSectionFeature.Models
{
    public class SaveUserScheduleSectionModel
    {
        public int Id { get; set; }
        public int UserScheduleId { get; set; }
        public int ClassRoomSubjectId { get; set; }
    }
}
