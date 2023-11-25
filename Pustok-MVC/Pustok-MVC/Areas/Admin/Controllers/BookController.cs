using Microsoft.AspNetCore.Mvc;
using Pustok_MVC.Areas.Admin.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Pustok_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        AppDbContext _db;
        private readonly IWebHostEnvironment _environment;
        AdminVM adminVM = new AdminVM();
        public BookController(AppDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }
        public IActionResult Index()
        {
            List<Book> books = _db.books.ToList();
            return View(books);

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {

            if (book.ImagesFiles == null || book.ImagesFiles.Count == 0)
            {
                ModelState.AddModelError("ImagesFiles", "En az bir foto seç");
            }
            else
            {
                foreach (var file in book.ImagesFiles)
                {
                    if (!file.ContentType.Contains("image"))
                    {
                        ModelState.AddModelError("ImagesFiles", "Yalnizca Sekil yukluye bilersiz");
                    }

                    if (file.Length > 2097152)
                    {
                        ModelState.AddModelError("ImagesFiles", "Maxsimum 2mb yukluye bilersiz!");
                    }
                }
            }
          
            _db.books.Add(book);
             _db.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Update(int id)
        {
            Book book = _db.books.Find(id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Update(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            Book oldbook = _db.books.Find(book.Id);
            oldbook.Name = book.Name;
            oldbook.Price = book.Price;
            oldbook.Description = book.Description;

            _db.books.Add(oldbook);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
