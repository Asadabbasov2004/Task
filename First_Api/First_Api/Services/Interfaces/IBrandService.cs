using First_Api.DTOs.BrandDTOs;
using First_Api.Entities;

namespace First_Api.Services.Interfaces
{
    public interface IBrandService
    {
        Task<IQueryable<Brand>> GetAll();
        Task<Brand> GetById(int id);
        Task<Brand> Create(CreateBrandDto createBrandDto);
    }
}
