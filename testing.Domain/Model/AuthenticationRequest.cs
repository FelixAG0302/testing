

namespace testing.Domain.Model
{
    public class AuthenticationRequest
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
    public class AuthenticationResponce
    {
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public List<String> Roles { get; set; }
    }
    public class RegisterResponce
    {
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
    }
}
