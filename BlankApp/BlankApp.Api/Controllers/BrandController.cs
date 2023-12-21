using BlankApp.Business.DTOs.Brand;
using BlankApp.Business.Services.Interfaces;
using BlankApp.DAL.Repositories.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlankApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _repository;
        private readonly IBrandService _service;

        public BrandController(IBrandRepository repository, IBrandService service)
        {
            _repository = repository;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _service.GetAll();
            return StatusCode(StatusCodes.Status200OK, brands);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var Brand = await _service.GetById(id);

            return StatusCode(StatusCodes.Status200OK, Brand);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBrandDto createBrandDto)
        {
            var brand = await _service.Create(createBrandDto);
            return StatusCode(StatusCodes.Status201Created, brand);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, string name)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var brands = await _repository.GetById(id);
            if (brands == null) return StatusCode(StatusCodes.Status404NotFound);
            brands.Name = name;
            _repository.Update(brands);
            await _repository.SaveChangeAsync();

            return StatusCode(StatusCodes.Status200OK, brands);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var brand = await _repository.GetById(id);

            if (brand == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            _repository.Delete(brand);

            await _repository.SaveChangeAsync();

            return StatusCode(StatusCodes.Status200OK, brand);
        }
    }
}
