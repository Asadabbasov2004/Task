using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.Category
{
    public class CreateCategoryDto
    {
        public string? Name { get; set; }
        public IFormFile? LogoImg { get; set; }
    }
    public class CategoryCreateDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CategoryCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category Name is important.")
                .MinimumLength(3).WithMessage("must be at least 3 letters")
                .MaximumLength(100).WithMessage("max length-100");
        }
    }
}
