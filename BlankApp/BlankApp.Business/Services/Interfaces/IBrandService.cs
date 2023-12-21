using BlankApp.Business.DTOs.Brand;
using BlankApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp.Business.Services.Interfaces
{
    public interface IBrandService
    {
        Task<IQueryable<Brand>> GetAll();
        Task<Brand> GetById(int id);
        Task<Brand> Create(CreateBrandDto createBrandDto);
    }
}
