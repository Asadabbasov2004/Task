using Microsoft.AspNetCore.Mvc;

namespace Pronia_MVC.Areas.Admin.Controllers
{
        [Area("Admin")] 
    public class CategoryController : Controller
    {

        AppDbContext _context;
        public CategoryController(AppDbContext  context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> categories =  _context.categories.Include(p => p.Products).ToList();
            return View(categories);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
             _context.categories.Add(category); 
             _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            Category category =  _context.categories.Find(id);
             _context.categories.Remove(category);
             _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            Category category =  _context.categories.Find(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(Category newcategory)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Category oldcategory =  _context.categories.Find(newcategory.Id);
            oldcategory.Name = newcategory.Name;

             _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
