using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Pustok_MVC.Models;

namespace Pustok_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        AppDbContext _db;
        private readonly IWebHostEnvironment _environment;
        public BookController(AppDbContext db,IWebHostEnvironment environment)
        {
            _db=db;
            _environment=environment;
        }
        public IActionResult Index()
        {
            List<Book> books =_db.books.ToList() ;
            return View(books);

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            //if (!book.ImagesFiles.ContentType.Contains("image"))
            //{
            //    ModelState.AddModelError("ImageFile", "Yalnizca Sekil yukluye bilersiz");
            //    return View();
            //}
            //if (book.ImagesFiles.> 2097152)
            //{
            //    ModelState.AddModelError("ImageFile", "Maxsimum 2mb yukluye bilersiz!!");
            //    return View();
            //}
         //   book.BookImgs = book.ImagesFiles.Upload(_environment.WebRootPath, @"\Upload\SliderImage\");

            _db.books.Add(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Book book =_db.books.Find(id);
            return View(book);
        }
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

            _db.SaveChanges();
            return RedirectToAction("Update");
        }
    }
}
