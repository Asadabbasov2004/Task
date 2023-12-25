using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyApp.Business.DTOs.BaseDtos;

namespace UdemyApp.Business.DTOs.CategoryDtos
{
    public class CategoryUpdateDto:BaseEntityDto
    {
        public string Title { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
