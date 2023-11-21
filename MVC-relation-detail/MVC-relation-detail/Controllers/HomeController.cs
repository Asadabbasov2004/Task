using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_relation_detail.DAL;
using MVC_relation_detail.ViewModals;

namespace MVC_relation_detail.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM();
            List<Food> foodWithImage = _context.Foods
                .Include(x => x.Catagory)
                .Include(x => x.Images).ToList();
            homeVM.foodWithImage = foodWithImage;
            return View(homeVM);
        }
    }
}
