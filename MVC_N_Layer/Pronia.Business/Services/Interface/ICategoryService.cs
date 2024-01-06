using Pronia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Pronia.Business.Services.Interface
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetAllAsync();
        Task<bool> CreateAsync(CreateCategoryVm createDto);
        Task<CategoryGetDto> GetByIdAsync(int id);
        Task<bool> UpdateAsync(CategoryUpdateDto updateDto);
        Task Remove(int id);
    }
}
