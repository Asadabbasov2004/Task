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
            homeVM.books = _context.books.Include(p => p.BookImgs).ToList();
            return View(homeVM);
        }
    }
}
