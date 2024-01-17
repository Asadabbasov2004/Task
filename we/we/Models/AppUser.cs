using Microsoft.AspNetCore.Identity;

namespace we.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
