using testing.Application.Features.Application.UserScheduleSectionFeature.Models;


namespace testing.Application.Features.Application.UserScheduleFeature.Model
{
    public class SaveUserScheduleModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<SaveUserScheduleSectionModel> sections { get; set; }
    }
}
