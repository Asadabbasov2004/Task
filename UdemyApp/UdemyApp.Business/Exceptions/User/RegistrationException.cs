using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyApp.Business.Exceptions.User
{
    public class RegistrationException:Exception
    {
        public RegistrationException() : base("Username/Email or password is not true") { }

        public RegistrationException(string? message) : base(message)
        {
        }
    }
}
