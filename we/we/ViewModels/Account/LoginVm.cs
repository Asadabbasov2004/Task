using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace we.ViewModels.Account
{
    public class LoginVm
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
    public class LoginVmValidation : AbstractValidator<LoginVm>
    {
        public LoginVmValidation()
        {
            RuleFor(x => x.UsernameOrEmail)
                   .NotEmpty()
                   .WithMessage("Do not empty");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Do not empty");
        }
    };
}
