using Microsoft.AspNetCore.Identity;

namespace Gamma_News.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth {get;set;}
        public string Email { get; set; }
        public string Password { get; set; }
       
    }
}
