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
            //Product product=_context.products.on
            return View();
        }
    }
}
