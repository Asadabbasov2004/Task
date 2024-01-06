using Pronia.Business.DTOs.BaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Business.DTOs.CategoryDtos
{
    public class CategoryGetDto:BaseAuditableEntityDto
    {
        public string Title { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
