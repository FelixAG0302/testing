using testing.Domain.Entities;

namespace testing.Application.Features.Application.UserScheduleFeature.Model
{
    public class UserScheduleModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ClassRoomSubjectId { get; set; }
        public ClassRoomSubject ClassRoomSubject { get; set; }
    }
}
