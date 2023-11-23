using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pustok_MVC.Controllers
{
    public class BlogController : Controller
    {
        DbContext _context;

        public BlogController(DbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
      

            return View();
        }
    }
}
