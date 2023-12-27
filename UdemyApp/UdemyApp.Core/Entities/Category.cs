using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyApp.Core.Entities.Common;

namespace UdemyApp.Core.Entities
{
    public class Category:BaseAudiTableEntity
    {
        public string Title { get; set; }
        public int? ParentCategoryId { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category>? Children { get; set; }

        //public static implicit operator Category(UdemyApp.Business.DTOs.CategoryDtos.CategoryGetDto v)
        //{
        //    throw new NotImplementedException();
        //}

        //public static implicit operator Category(UdemyApp.Business.DTOs.CategoryDtos.CategoryGetDto v)
        //{
        //    throw new NotImplementedException();
        //}

        //public static implicit operator Category(UdemyApp.Business.DTOs.CategoryDtos.CategoryGetDto v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
