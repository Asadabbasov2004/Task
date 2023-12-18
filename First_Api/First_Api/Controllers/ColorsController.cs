using First_Api.DAL;
using First_Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using Color = First_Api.Entities.Color;

namespace First_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ColorsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Color> Colors = await _context.Colors.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, Colors);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Colors = await _context.Colors.SingleOrDefaultAsync(c => c.Id == id);
            return StatusCode(StatusCodes.Status200OK, Colors);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Color color)
        {
            await _context.Colors.AddAsync(color);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, color);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, string name)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var colors = await _context.Colors.FirstOrDefaultAsync(c => c.Id == id);
            if (colors == null) return StatusCode(StatusCodes.Status404NotFound);
            colors.Name = name;
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, colors);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var colors = await _context.Colors.FirstOrDefaultAsync(c => c.Id == id);

            if (colors == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            _context.Colors.Remove(colors);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, colors);
        }
    }
}
