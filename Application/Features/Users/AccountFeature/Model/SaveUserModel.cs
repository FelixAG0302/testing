namespace testing.Application.Features.Users.AccountFeature.Model
{
    public class SaveUserModel
    {
        public string Role { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int DegreeId { get; set; }
    }
}
