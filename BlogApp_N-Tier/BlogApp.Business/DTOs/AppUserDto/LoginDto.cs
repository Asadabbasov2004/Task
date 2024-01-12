using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.AppUserDto
{
    public record LoginDto
    {
        public string UserNameorEmail { get; set; }
        public string Password { get; set; }

    }
    public class LoginDtoValidation : AbstractValidator<LoginDto>
    {
        public LoginDtoValidation()
        {
            RuleFor(l => l.UserNameorEmail)
                .NotEmpty()
                .WithMessage("UserName/Email is not empty");
            RuleFor(l => l.Password)
                .NotEmpty()
                .WithMessage("Password is not empty");
        }
    }
}
