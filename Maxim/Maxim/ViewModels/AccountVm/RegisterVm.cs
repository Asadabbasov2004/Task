using System.ComponentModel.DataAnnotations;

namespace Maxim.ViewModels.AccountVm
{
    public class RegisterVm
    {
        [Required(ErrorMessage = "Required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Minium 3 ,Maximum 30 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Minium 3 ,Maximum 30 characters")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Minium 3 ,Maximum 30 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Minium 3 ,Maximum 30 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
