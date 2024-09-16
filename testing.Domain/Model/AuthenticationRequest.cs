

using System.ComponentModel.DataAnnotations;

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
        public List<string> Roles { get; set; }
        public int DegreeId { get; set; }
    }
    public class RegisterRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cedula { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }

        public DateTime BirthDay { get; set; }
    }
    public class RegisterResponce
    {
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
    }
}
