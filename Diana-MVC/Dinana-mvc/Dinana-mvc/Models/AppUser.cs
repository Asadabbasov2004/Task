using Microsoft.AspNetCore.Identity;

namespace Dinana_mvc.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsRemained { get; set; }
    }
}
