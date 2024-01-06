using AutoMapper;
using Pronia.Business.DTOs.CategoryDtos;
using Pronia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyApp.Business.DTOs.CategoryDtos;
namespace Pronia.Business.Profiles
{
    public class CategoryMapProfile:Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryCreateDto, Category>().ReverseMap();
            CreateMap<CategoryGetDto, Category>();
            CreateMap<CategoryGetDto, Category>().ReverseMap();
            CreateMap<CategoryListitemDto, Category>();
            CreateMap<CategoryListitemDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();

        }
    }
}
