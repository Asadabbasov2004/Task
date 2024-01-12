using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.AppUserDto
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class AccountRegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public AccountRegisterDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(25)
                .WithMessage("Name cannot be longer than 25 characters");
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname is required")
                .MaximumLength(45)
                .WithMessage("Surname cannot be longer than 45 characters");
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required")
                .MaximumLength(60)
                .WithMessage("Username cannot be longer than 60 characters");
            RuleFor(x => x.Email)
              .NotEmpty().WithMessage("Email is required")
              .MaximumLength(60)
              .WithMessage("Email cannot be longer than 60 characters")
              .Must(x => IsValidEmail(x)).WithMessage("Invalid email format");
            RuleFor(x => x.Password)
              .NotEmpty().WithMessage("Password is required")
              .MaximumLength(20)
              .WithMessage("Password cannot be longer than 20 characters")
              .Must(x =>
              {
                  Regex regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
                  Match match = regex.Match(x);
                  return match.Success;

              }).WithMessage("Incorrect format");
            RuleFor(x => x.ConfirmPassword)
              .Equal(x => x.Password).WithMessage("Passwords do not match")
              .WithMessage("passwords is not equal each other");
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}

