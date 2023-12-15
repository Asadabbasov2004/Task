using Indigo_Mvc.Areas.Admin.ViewModels.Product;
using Indigo_Mvc.DAL;
using Indigo_Mvc.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Indigo_Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        AppDbContext _db;

        public ProductController(AppDbContext db,IWebHostEnvironment environment)
        {
            _db = db;
            _env = environment;
        }

        readonly IWebHostEnvironment _env;

        public async Task< IActionResult> Index()
        {
            ViewBag.Product = _db.Products.Include(p => p.Images).FirstOrDefault();
            return View();
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Product = _db.Products.Include(p => p.Images).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVm createProductVm)
        {
            ViewBag.Product =await _db.Products.Include(p => p.Images).FirstOrDefaultAsync();
            if (!ModelState.IsValid)
            {
                return View();

            }
            Product product = new Product()
            {
                Name = createProductVm.Name,
                Title= createProductVm.Title,
                Description = createProductVm.Description,
                Images = new List<Images>()
                
            };

            if(createProductVm.AllPhotos != null)
            {
                foreach(var item in createProductVm.AllPhotos)
                {
                    if (!item.CheckType("/image"))
                    {
                        return View();
                    }
                    if (!item.CheckLength(3000))
                    {
                        return View();

                    }

                    Images image = new Images()
                    {
                        Product = product,
                        Url = item.UploadFile(_env.WebRootPath, @"\Upload"),
                    };
                    product.Images.Add(image);
                }
            }
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
  
        }
        [HttpPost]
        public async Task<IActionResult> Update()
        {
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result =await _db.Products.FirstOrDefaultAsync(p=>p.Id ==id);
            if(result != null)
            {
               _db.Products.Remove(result);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));

        }

    }
}
