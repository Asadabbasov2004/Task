using System.ComponentModel.DataAnnotations;

namespace FruitShopMVC.ViewModels.AccountVm
{
    public class LoginVm
    {
        [Required]
        [MinLength(3, ErrorMessage = "must be at least 3 letters")]
        public string UserNameOrEmail { get; set; }
        [Required]
        [MinLength(3)]
        [DataType(DataType.Password, ErrorMessage = "Password is only this item  ,must be 6 letter and use at least one number and une non-alpeberic ,one Capital letter")]
        public string Password { get; set; }
    }
}
