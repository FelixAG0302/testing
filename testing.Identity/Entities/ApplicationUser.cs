using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace testing.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [StringLength(11, ErrorMessage = "A cedula is 11 character long")]
        public string Cedula { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
