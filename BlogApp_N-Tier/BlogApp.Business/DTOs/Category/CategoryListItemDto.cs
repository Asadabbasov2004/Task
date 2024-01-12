using BlogApp.Business.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.Category
{
    public class CategoryListitemDto : BaseAudiTableDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public int? ParentCategoryId { get; set; }

    }
}
