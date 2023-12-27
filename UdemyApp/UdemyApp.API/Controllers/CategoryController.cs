using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyApp.Business.DTOs.CategoryDtos;
using UdemyApp.Business.Exceptions.Category;
using UdemyApp.Business.Exceptions.Common;
using UdemyApp.Business.Services.Interface;
using UdemyApp.Core.Entities;
using System.Threading.Tasks;
namespace UdemyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _service;


        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var brands = await _service.GetAllAsync();
            return StatusCode(StatusCodes.Status200OK, brands);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var brand = await _service.GetByIdAsync(id);
            return StatusCode(StatusCodes.Status200OK, brand);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateDto categoryCreateDto)
        {
            bool result = await _service.CreateAsync(categoryCreateDto);
            if (result)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return StatusCode(StatusCodes.Status409Conflict);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] CategoryUpdateDto updateCategoryDto)
        {
            try
            {
                if (await _service.UpdateAsync(updateCategoryDto)) return Ok();
                return StatusCode(StatusCodes.Status502BadGateway);
            }
            catch (NegativeIdException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (CategoryNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpDelete("id")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
            await _service.Remove(id);
            return StatusCode(StatusCodes.Status200OK);
            }
            catch (NegativeIdException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (CategoryNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }


        //[HttpDelete("DeleteAll")]
        //public async Task<IActionResult> DeleteAll()
        //{
        //    await _service.deleteAll();
        //    return StatusCode(StatusCodes.Status200OK);
        //}
    }
}
