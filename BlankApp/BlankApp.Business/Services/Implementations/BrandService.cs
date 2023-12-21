using AutoMapper;
using BlankApp.Business.DTOs.Brand;
using BlankApp.Business.Services.Interfaces;
using BlankApp.Core.Entities;
using BlankApp.DAL.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp.Business.Services.Implementations
{
    public class BrandService:IBrandService
    {
        private readonly IBrandRepository _repository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _repository = brandRepository;
            _mapper = mapper;
        }



        public async Task<IQueryable<Brand>> GetAll()
        {
            return await _repository.GetAllAsync(orderbyExpression: c => c.Name, isDescending: true);
        }

        public async Task<Brand> GetById(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            var brand = await _repository.GetById(id);
            if (brand == null) throw new Exception("Not Found");
            return brand;
        }
        public async Task<Brand> Create(CreateBrandDto createBrandDto)
        {
            if (createBrandDto == null) throw new Exception("Not null");
            Brand brand = _mapper.Map<Brand>(createBrandDto);
            await _repository.Create(brand);
            await _repository.SaveChangeAsync();
            return brand;
        }
    }
}
