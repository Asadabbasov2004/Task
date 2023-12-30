using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UdemyApp.Business.DTOs.UserDtos
{
    public record RegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class RegisterDtoValidation : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidation()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(25)
            .WithMessage("Name cannot be longer than 25 characters");
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname is required 2")
                .MaximumLength(25)
                .WithMessage("Surname cannot be longer than 25 characters");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required")
                .MaximumLength(30)
                .WithMessage("Username cannot be longer than 30 characters");
            RuleFor(x => x.Email)
             .EmailAddress().MaximumLength(50)
             .NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Password)
              .NotEmpty().WithMessage("Password is required")
              .MaximumLength(20)
              .WithMessage("Password cannot be longer than 20 characters")
              .Must(x =>
              {
                  //  1 .Regex regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
                  //                  En az bir büyük harf içermeli: (?=.*?[A - Z])
                  //En az bir küçük harf içermeli: (?=.*?[a - z])
                  //En az bir sayı içermeli: (?=.*?[0 - 9])
                  //En az bir özel karakter içermeli(#?!@$%^&*- gibi): (?=.*?[#?!@$%^&*-])
                  //Toplam uzunluğu en az 8 karakter olmalı: .{ 8,}
                 if(x is not null)
                  {
                  Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)[A-Za-z\d]{4,}$");
                  Match match = regex.Match(x);
                  return match.Success;
                  }
                 else { return false; }
              }).WithMessage("Incorrect format");
            RuleFor(x => x.ConfirmPassword)
              .Equal(x => x.Password).WithMessage("Passwords do not match");
              
        }
    }
}
