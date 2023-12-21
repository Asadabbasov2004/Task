using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Second_Api.Services;
using Second_Api.Repostories;
using Second_Api.Repostories.Abstraction;
using Second_Api.Services.Interfaces;
namespace Second_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryService _service;

        public CategoryController(ICategoryRepository repository, ICategoryService service)
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
        public async Task<IActionResult> Create([FromForm] CreateCategoryDto createCategoryDto)
        {
            var category = await _service.Create(createCategoryDto);
            return StatusCode(StatusCodes.Status201Created, category);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateCategoryDtos updateCategoryDtos)
        {
            var oldCategory = await _service.Update(id, updateCategoryDtos);
            return StatusCode(StatusCodes.Status200OK, oldCategory);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
