using AutoMapper;
using BlogApp.Business.DTOs.Category;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyApp.Business.Profiles
{
    public class CategoryMapProfile:Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<CategoryGetDto, Category>().ReverseMap();
            CreateMap<CategoryListitemDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();

        }
    }
}
