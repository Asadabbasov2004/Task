using System.ComponentModel.DataAnnotations;

namespace Maxim.ViewModels.AccountVm
{
    public class LoginVm
    {
        [Required(ErrorMessage = "Required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Minium 3 ,Maximum 30 characters")]
        public string UserNameOrEmail { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Minium 3 ,Maximum 30 characters")]
        public string Password { get; set; }
    }
}
