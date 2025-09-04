using Microsoft.AspNetCore.Identity;

namespace LoginUsers.Models
{
    public class User : IdentityUser
    {
        public DateTime DateOfBirth { get; set; }

        public User() : base() { }
    }
}
