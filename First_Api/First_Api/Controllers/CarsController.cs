using First_Api.DAL;
using First_Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Car> Cars = await _context.Cars.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, Cars);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Cars = await _context.Cars.SingleOrDefaultAsync(c => c.Id == id);
            return StatusCode(StatusCodes.Status200OK, Cars);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Car cars)
        {
            await _context.Cars.AddAsync(cars);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, cars);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, string name,int brandId ,int colorid,int modelyear,double price,string description)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var cars = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (cars == null) return StatusCode(StatusCodes.Status404NotFound);
            cars.Name = name;
            cars.BrandId = brandId;
            cars.ColorId = colorid;
            cars.ModelYear = modelyear;
            cars.DailyPrice = price;
            cars.Description = description;

            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, cars);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var cars = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);

            if (cars == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            _context.Cars.Remove(cars);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, cars);
        }
    }
}
