﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyApp.Business.DTOs.CategoryDtos
{
    public class CategoryCreateDto
    {
        public string Title { get; set; }
        public int? ParentCategoryId {get; set; }
    }
}
