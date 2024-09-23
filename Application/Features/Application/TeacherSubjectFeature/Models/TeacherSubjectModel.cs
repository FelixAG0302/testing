using testing.Application.Features.Application.SubjectFeature.Models;
using testing.Application.Features.Users.UsersManagementFeature.Models;

namespace testing.Application.Features.Application.TeacherSubjectFeature.Models
{
    public class TeacherSubjectModel
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int TecherId { get; set; }
        public SubjectModel Subject { get; set; }
        public TeacherModel Teacher { get; set; }
    }
}
