using Microsoft.AspNetCore.Mvc;
using Pronia_MVC.DAL;
namespace Pronia_MVC.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            HomeVm homeVm = new HomeVm()
            {
                sliders = await _db.Sliders.ToListAsync(),
                products = await _db.Products.Include(p => p.ProductImages).ToListAsync()
            };

            return View(homeVm);
        }
    }
}
