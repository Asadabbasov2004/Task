using Microsoft.AspNetCore.Mvc;

namespace Pustok_MVC.Areas.Admin.Controllers
{
        [Area("Admin")]
    public class CategoryController : Controller
    {
        AppDbContext _db;
        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Catagory> catagories =_db.catagories.ToList();
            return View(catagories);
        }
        public IActionResult Create()
        {
           return View() ;
        }
        [HttpPost]
        public IActionResult Create(Catagory category)
        {
            _db.catagories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index"); 
        }


    }
}
