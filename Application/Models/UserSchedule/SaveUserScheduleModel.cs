
using testing.Application.Models.UserScheduleSection;


namespace testing.Application.Models.UserSchedule
{
    public class SaveUserScheduleModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<SaveUserScheduleSectionModel> sections { get; set; }
    }
}
