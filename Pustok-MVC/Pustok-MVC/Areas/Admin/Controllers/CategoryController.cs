using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pustok_MVC.Areas.Admin.ViewModels.BookVm;

namespace Pustok_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        AppDbContext _db;
        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Catagory> catagories = _db.catagories.Include(p=>p.books).Include(p=>p.blogs).ToList();
            return View(catagories);
        }
        public async Task< IActionResult> Create()
        {
            ViewBag.Blog =await _db.blogs.ToListAsync();
            ViewBag.Book =await _db.books.ToListAsync();
             return View();
        }
        [HttpPost]
        public async Task< IActionResult> Create(CreateBookVm createBookVm)
        {
            ViewBag.Blog = await _db.blogs.ToListAsync();
            ViewBag.Book = await _db.books.ToListAsync();
            if (!ModelState.IsValid)
            {
                return View();
            }

            Catagory catagory = new Catagory()
            {
                Name = createBookVm.Name,
                CatagoryId = createBookVm.CatagoryId,
            };

            await _db.catagories.AddAsync(catagory);
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
