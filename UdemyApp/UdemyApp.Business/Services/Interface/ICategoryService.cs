using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyApp.Business.DTOs.CategoryDtos;
using UdemyApp.Core.Entities;

namespace UdemyApp.Business.Services.Interface
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryListitemDto>> GetAllAsync();
        Task<bool> CreateAsync(CategoryCreateDto createDto);
        Task<CategoryGetDto> GetByIdAsync(int id);
        Task<bool> UpdateAsync(CategoryUpdateDto updateDto);
    }
}
