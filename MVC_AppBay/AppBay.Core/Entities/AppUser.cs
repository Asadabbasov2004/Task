using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AppBay.Core.Entities
{
    public class AppUser:IdentityUser
    {
        public string Name {  get; set; }
        public string Surname {  get; set; }
        public bool Rememberme {  get; set; }
    }
}
