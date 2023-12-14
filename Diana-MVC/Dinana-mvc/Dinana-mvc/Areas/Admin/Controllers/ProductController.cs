using Dinana_mvc.Areas.Admin.ViewModels.Product;
using Dinana_mvc.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Dinana_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = await _db.Products.Include(p => p.Images).Include(p => p.Categories)
                .Include(p => p.ProductColors).ThenInclude(p => p.Color)
                .Include(p => p.ProductMaterials).ThenInclude(p => p.Material)
                .Include(p => p.ProductSizes).ThenInclude(p => p.Size)
                .ToListAsync();
            return View(products);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Colors = await _db.Colors.ToListAsync();
            ViewBag.Materials = await _db.Materials.ToListAsync();
            ViewBag.Sizes = await _db.Sizes.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVm createProductVm)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Colors = await _db.Colors.ToListAsync();
            ViewBag.Materials = await _db.Materials.ToListAsync();
            ViewBag.Sizes = await _db.Sizes.ToListAsync();

            if (!ModelState.IsValid) { return View(); }
            var result = await _db.Categories.AnyAsync(p => p.Id == createProductVm.CategoryId);
            if (!result)
            {
                ModelState.AddModelError("CategoryId", "bele bir id yoxdur");
                return View();
            }

            Product product = new Product()
            {
                Name = createProductVm.Name,
                Description = createProductVm.Description,
                Price = createProductVm.Price,
                // Count = createProductVm.Count,
                CategoryId = createProductVm.CategoryId,
                Images = new List<productImages>()
            };

            if (createProductVm.SizeIds != null)
            {
                foreach (int sizeId in createProductVm.SizeIds)
                {
                    bool resultSize = await _db.Sizes.AnyAsync(c => c.Id == sizeId);
                    if (!resultSize)
                    {
                        ModelState.AddModelError("SizeIds", $"Mehsulun bele bir size yoxdu {sizeId}");
                        return View();
                    }

                    ProductSizes productSizes = new ProductSizes()
                    {
                        Product = product,
                        SizeId = sizeId
                    };
                    _db.ProductSizes.AddAsync(productSizes);
                }
            }
            if (createProductVm.ColorIds != null)
            {
                foreach (var colorId in createProductVm.ColorIds)
                {
                    bool resultColor = await _db.Colors.AnyAsync(p => p.Id == colorId);
                    if (!resultColor)
                    {
                        ModelState.AddModelError("ColorIds", "Bele bir reng yoxdu");
                        return View();
                    }
                    ProductColor productColor = new ProductColor()
                    {
                        Product = product,
                        ColorId = colorId
                    };
                    _db.ProductColors.AddAsync(productColor);
                }
            }
            if (createProductVm.MaterialIds != null)
            {
                foreach (var materialId in createProductVm.MaterialIds)
                {
                    bool resultColor = await _db.Colors.AnyAsync(p => p.Id == materialId);
                    if (!resultColor)
                    {
                        ModelState.AddModelError("MaterialIds", "Bele bir material yoxdu");
                        return View();
                    }
                    ProductMaterial productMaterial = new ProductMaterial()
                    {
                        Product = product,
                        MaterialId = materialId
                    };
                    _db.ProductMaterials.AddAsync(productMaterial);
                }
            }

            if (!createProductVm.Mainphoto.CheckType("/image"))
            {
                ModelState.AddModelError("Mainphoto", "only photo");
                return View();
            }
            if (!createProductVm.Mainphoto.CheckLength(3000))
            {
                ModelState.AddModelError("Mainphoto", "size bigger than 3mb");
                return View();
            }
            productImages MainImage = new productImages()
            {
                IsActive = true,
                ImageUrl = createProductVm.Mainphoto.UploadFile(_env.WebRootPath, @"\Upload\Product"),
                Product = product,
            };

            product.Images.Add(MainImage);

            TempData["Error"] = "";
            if (createProductVm.AllPhotos != null)
            {
                foreach (var photo in createProductVm.AllPhotos)
                {
                    if (!photo.CheckType("/image"))
                    {
                        TempData["Error"] += "1.only image \t";
                        continue;
                    };
                    if (!photo.CheckLength(3000))
                    {
                        TempData["Error"] += "1.size is large \t";
                        continue;
                    };

                    productImages images = new productImages()
                    {
                        IsActive = false,
                        ImageUrl = photo.UploadFile(_env.WebRootPath, @"\Upload\Product"),
                        Product =product,
                    };
                    product.Images.Add(images);
                }
            }

            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            Product product = await _db.Products.Where(p => p.Id == id).Include(p => p.Images).Include(p => p.Categories)
                .Include(p => p.ProductColors).ThenInclude(p => p.Color)
                .Include(p => p.ProductMaterials).ThenInclude(p => p.Material)
                .Include(p => p.ProductSizes).ThenInclude(p => p.Size).FirstOrDefaultAsync();
            if(product is null)
            {
                return View();
            }
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Colors = await _db.Colors.ToListAsync();
            ViewBag.Materials = await _db.Materials.ToListAsync();
            ViewBag.Sizes = await _db.Sizes.ToListAsync();
            
            UpdateProductVm updateProductVm = new UpdateProductVm()
            {
                Id = id,
                Name =product.Name,
                Description = product.Description,
                Price = product.Price,
                Count = product.Count,
                CategoryId =product.CategoryId ,
                SizeIds = new List<int>(),
                MaterialIds = new List<int>(),
                ColorIds = new List<int>(),
                Images = new List<UpdateImagesVm>()
            };
            foreach (var item roduct.ProductSizes)
            {
                updateProductVm.SizeIds.Add(item.);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductVm updateProductVm)
        {

        }
    }
}
