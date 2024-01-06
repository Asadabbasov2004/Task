using Pronia.Business.DTOs.BaseDtos;
using System;

namespace UdemyApp.Business.DTOs.CategoryDtos
{
    public class CategoryUpdateDto:BaseEntityDto
    {
        public string Title { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
