using AutoMapper;
using First_Api.DTOs.BrandDTOs;
using First_Api.Entities;
using First_Api.Repositories.Abstraction;
using First_Api.Services.Interfaces;

namespace First_Api.Services.Implimentations
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository,IMapper mapper)
        {
            _repository = brandRepository;
            _mapper = mapper;
        }



        public async Task<IQueryable<Brand>> GetAll()
        {
            return await _repository.GetAll(orderbyExpression: c => c.Name, isDescending: true);
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

