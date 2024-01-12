using BlogApp.Business.DTOs.Category;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetAllAsync();
        Task<Category> GetById(int id);
        Task<bool> Create(CreateCategoryDto createCategoryDto); 
        Task Delete(int id);
        Task deleteAll();
        Task Update(UpdateCategoryDto updateCategoryDto);
    }
}
