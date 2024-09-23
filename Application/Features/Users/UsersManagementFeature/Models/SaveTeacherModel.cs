namespace testing.Application.Features.Users.UsersManagementFeature.Models
{
    public class SaveTeacherModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cedula { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        public bool IsOnVacation { get; set; }
    }
}
