using Microsoft.AspNetCore.Mvc;

namespace Pronia_MVC.Controllers
{
    public class ShopController : Controller
    {
        AppDbContext _context;
        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Product? product=_context.products
            .Include(p=>p.Category)
            .Include(p=>p.ProductImages)
            .Include(p=>p.productTags)
            .ThenInclude(pt=>pt.Tag)
            .FirstOrDefault(product => product.Id ==id);
            if (product == null) return BadRequest();
            return View(product);
        }
    }
}
