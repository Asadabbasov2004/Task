using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.Category
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IFormFile? LogoImg { get; set; }
    }
    public class CategoryUpdateDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category Name is important..")
                .MinimumLength(3).WithMessage("must be at least 3 letters")
                .MaximumLength(100).WithMessage("max length-100");
        }
    }
}
