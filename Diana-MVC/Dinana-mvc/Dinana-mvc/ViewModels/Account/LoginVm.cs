using System.ComponentModel.DataAnnotations;

namespace Dinana_mvc.ViewModels.Account
{
    public class LoginVm
    {
        public string EmailOrUsername { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
