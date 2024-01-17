using System.ComponentModel.DataAnnotations;

namespace we.ViewModels.Account
{
    public class RegisterVm
    {
        [Required]
        public string Name {  get; set; }
        [Required]
        public string Surname {  get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string UserName {  get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
