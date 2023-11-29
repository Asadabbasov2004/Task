using Microsoft.AspNetCore.Mvc;
using Pustok_MVC.Areas.Admin.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Http;
using Pustok_MVC.Areas.Admin.ViewModels.Book;

namespace Pustok_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        AppDbContext _db;
        private readonly IWebHostEnvironment _environment;
    
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
        public async Task<IActionResult> Create()
        {
            ViewBag.Authors = await _db.authors.ToListAsync();
            ViewBag.Tags =await _db.tags.ToListAsync();
            ViewBag.Category =await _db.catagories.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookVm createBookVm)
        {
            ViewBag.Authors = await _db.authors.ToListAsync();
            ViewBag.Tags = await _db.tags.ToListAsync();
            ViewBag.Category = await _db.catagories.ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }
            //if (book.ImagesFiles == null || book.ImagesFiles.Count == 0)
            //{
            //    ModelState.AddModelError("ImagesFiles", "En az bir foto seç");
            //}
            //else
            //{
            //    foreach (var file in book.ImagesFiles)
            //    {
            //        if (!file.ContentType.Contains("image"))
            //        {
            //            ModelState.AddModelError("ImagesFiles", "Yalnizca Sekil yukluye bilersiz");
            //        }

            //        if (file.Length > 2097152)
            //        {
            //            ModelState.AddModelError("ImagesFiles", "Maxsimum 2mb yukluye bilersiz!");
            //        }
            //    }
            //}

            bool resultCategory = await _db.authors.AnyAsync(c => c.Id == createBookVm.AuthorId);
            if (!resultCategory)
            {
                ModelState.AddModelError("AuthorId", "Bele bir catagory movcud deyil");
                return View();
            }
            Book book = new Book()
            {
                Name = createBookVm.Name,
                Description = createBookVm.Description,
                Price = createBookVm.Price,
                AuthorId = createBookVm.AuthorId,

            };
          //  if(Book)

            await _db.books.AddAsync(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


  
        public async Task<IActionResult> Delete(int id)
        {
            var BookToDelete = await _db.books.FindAsync(id);

            if (BookToDelete == null)
            {
                return  View("Update");
            }

            _db.books.Remove(BookToDelete);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }



        //public IActionResult Update(int id)
        //{
        //    Book book = _db.books.Find(id);
        //    return View(book);
        //}
        //[HttpPost]
        //public IActionResult Update(Book book)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(book);
        //    }
        //    Book oldbook = _db.books.Find(book.Id);
        //    oldbook.Name = book.Name;
        //    oldbook.Price = book.Price;
        //    oldbook.Description = book.Description;
        //    oldbook.ImagesFiles = book.ImagesFiles;

        //    _db.books.Add(oldbook);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
