using Second_Api.DTOs;
namespace Second_Api.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IQueryable<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> Create(CreateCategoryDto createCategoryDto);
        Task<Category> Update(int id,UpdateCategoryDtos UpdateCategoryDtos);
        Task<Category> Delete(int id);
    }
}
