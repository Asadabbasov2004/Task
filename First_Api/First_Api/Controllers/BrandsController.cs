using First_Api.DAL;
using First_Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BrandsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Brand> brands = await _context.Brands.ToListAsync();
            return StatusCode(StatusCodes.Status200OK,brands);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Brand  = await _context.Brands.SingleOrDefaultAsync(c=>c.Id ==id);
            return StatusCode(StatusCodes.Status200OK, Brand);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Brand brand)
        {
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created ,brand);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id ,string name)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var brands = await _context.Brands.FirstOrDefaultAsync(c => c.Id == id);
             if(brands == null) return StatusCode(StatusCodes.Status404NotFound);
             brands.Name = name;
             await _context.SaveChangesAsync();
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

            var brand = await _context.Brands.FirstOrDefaultAsync(c => c.Id == id);

            if (brand == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, brand);
        }
    }
}
