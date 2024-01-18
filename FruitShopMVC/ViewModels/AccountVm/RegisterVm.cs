using System.ComponentModel.DataAnnotations;

namespace FruitShopMVC.ViewModels.AccountVm
{
    public class RegisterVm
    {
        [Required]
        [MinLength(3,ErrorMessage ="must be at least 3 letters")]

        public string Name {  get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "must be at least 3 letters")]
        public string Surname {  get; set; }

        [MinLength(8, ErrorMessage = "must be at least 8 letters")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Must be email,use @ ")]
        public string Email { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "must be at least 3 letters")]
        public string UserName { get; set; }
        [Required]
        [MinLength(3)]
        [DataType(DataType.Password, ErrorMessage = "Password is only this item  ,must be 6 letter and use at least one number and une non-alpeberic ,one Capital letter")]
        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage ="It is not same password")]
        public string ConfirmPassword {  get; set; }
      

    }
}
