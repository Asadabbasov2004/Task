using Pronia.Business.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyApp.Business.DTOs.CategoryDtos;

namespace Pronia.Business.Services.Interface
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryListitemDto>> GetAllAsync();
        Task<bool> CreateAsync(CategoryCreateDto createDto);
        Task<CategoryGetDto> GetByIdAsync(int id);
        Task<bool> UpdateAsync(CategoryUpdateDto updateDto);
        Task Remove(int id);
    }
}
