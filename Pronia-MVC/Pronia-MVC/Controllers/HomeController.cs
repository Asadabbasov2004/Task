using Microsoft.AspNetCore.Mvc;
using Pronia_MVC.DAL;
namespace Pronia_MVC.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async  Task<IActionResult> Index()
        {
            HomeVm homeVm = new HomeVm()
            {
                sliders=await _context.sliders.ToListAsync(),
                products = await _context.products.Include(p => p.ProductImages).ToListAsync() 
            };
            return View(homeVm);
        }
    }
}
