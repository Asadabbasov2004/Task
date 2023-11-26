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
            List<Catagory> catagories = _db.catagories.ToList();
            return View(catagories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Catagory category)
        {
            _db.catagories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id) {
            Catagory catagory = _db.catagories.Find(id);
            return View(catagory);
        }
        [HttpPost]
        public IActionResult Update(Catagory catagory)
        {
            if (!ModelState.IsValid)
            {
                return View(catagory);
            }
            Catagory oldcategory = _db.catagories.Find(catagory.Id);
            if (oldcategory != null)
            {
                oldcategory.Name = catagory.Name;
                oldcategory.CatagoryId = catagory.CatagoryId;
               // _db.catagories.Add(catagory);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }
}
