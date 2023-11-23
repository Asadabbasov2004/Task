using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pustok_MVC.ViewModels;

namespace Pustok_MVC.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["cat"] = _context.catagories.ToList();
            HomeVM homeVM = new HomeVM();
            homeVM.sliders=_context.slider.ToList();
            return View(homeVM);
        }
    }
}
