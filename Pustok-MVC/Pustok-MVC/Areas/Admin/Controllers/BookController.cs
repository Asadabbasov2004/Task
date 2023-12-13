using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Pustok_MVC.Areas.Admin.ViewModels.BookVm;

namespace Pustok_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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
            List<Book> books = _db.books.Include(b => b.bookTags).ThenInclude(bt => bt.Tag).Include(p => p.BookImgs).ToList();
            return View(books);

        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Authors = await _db.authors.ToListAsync();
            ViewBag.Tags = await _db.tags.ToListAsync();
            ViewBag.Category = await _db.catagories.ToListAsync();
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

            List<BookTags> bookTags = new();

            foreach (int tagId in createBookVm.TagIds)
            {

                bookTags.Add(new() { TagId = tagId });
            }

            Book book = new Book()
            {
                Name = createBookVm.Name,
                Description = createBookVm.Description,
                Price = createBookVm.Price,
                AuthorId = createBookVm.AuthorId,
                bookTags = bookTags,
                CatagoryId = createBookVm.CatagoryId,
                BookImgs = new List<BookImg>()
            };

            if (!createBookVm.MainPhoto.CheckType("image/"))
            {
                ModelState.AddModelError("MainPhoto", "Duzgun formatda sekil qoy");
                return View();
            }
            if (!createBookVm.MainPhoto.CheckLength(3000))
            {
                ModelState.AddModelError("MainPhoto", "Duzgun olcude (3mb) sekil qoy");
                return View();
            }
            if (!createBookVm.HoverPhoto.CheckType("image/"))
            {
                ModelState.AddModelError("HoverPhoto", "Duzgun formatda sekil qoy");
                return View();
            }
            if (!createBookVm.HoverPhoto.CheckLength(3000))
            {
                ModelState.AddModelError("HoverPhoto", "Duzgun olcude (3mb) sekil qoy");
                return View();
            }

            BookImg mainImg = new BookImg()
            {
                IsPrime = true,
                Url = createBookVm.MainPhoto.Upload(_environment.WebRootPath, @"\Upload\Product\"),
                Book = book,
            };

            BookImg hoverImg = new BookImg()
            {
                IsPrime = false,
                Url = createBookVm.HoverPhoto.Upload(_environment.WebRootPath, @"\Upload\Product\"),
                Book = book,
            };
            TempData["Error"] = "";
            if (createBookVm.Photos != null)
            {
                foreach (var item in createBookVm.Photos)
                {
                    if (!item.CheckType("image/"))
                    {
                        TempData["Error"] += $"{item.FileName}-bu duzgun formatda deyil ";
                        continue;
                    }
                    if (!item.CheckLength(3000))
                    {
                        TempData["Error"] += $"{item.FileName}- 3mb dan yuxaridir ";
                        continue;
                    }
                    BookImg newPhoto = new BookImg()
                    {
                        IsPrime = null,
                        Url = item.Upload(_environment.WebRootPath, @"\Upload\Product\"),
                        Book = book,
                    };
                    book.BookImgs.Add(newPhoto);
                }
            }
            book.BookImgs.Add(mainImg);
            book.BookImgs.Add(hoverImg);
            await _db.books.AddAsync(book);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Delete(int id)
        {
            var BookToDelete = await _db.books.FindAsync(id);

            if (BookToDelete == null)
            {
                return View("Update");
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
