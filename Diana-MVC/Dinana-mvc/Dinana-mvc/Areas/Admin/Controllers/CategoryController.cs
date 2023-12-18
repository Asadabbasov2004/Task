using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dinana_mvc.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CategoryController : Controller
    {
        AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin, Moderator")]
        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.Include(p => p.Products).ToList();
            return View(categories);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int Id)
        {
            Category category = _context.Categories.Find(Id);
            return View(category);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Update(Category newcategory)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Category oldcategory = _context.Categories.Find(newcategory.Id);
            oldcategory.Name = newcategory.Name;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {

            Category category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
