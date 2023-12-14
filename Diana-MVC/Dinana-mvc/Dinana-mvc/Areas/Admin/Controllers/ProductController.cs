using Dinana_mvc.Areas.Admin.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

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

        public async Task< IActionResult> Index()
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

            Product product= new Product()
            {
               Name = createProductVm.Name,
               Description = createProductVm.Description,
               Price = createProductVm.Price,
              // Count = createProductVm.Count,
              CategoryId = createProductVm.CategoryId,
              Images =new List<productImages>()
            };

            if(createProductVm.SizeIds != null)
            {
                foreach (int sizeId in createProductVm.SizeIds)
                {
                    bool resultSize =await _db.Sizes.AnyAsync(c=>c.Id == sizeId);
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
            if(createProductVm.ColorIds != null)
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

            return View();
        }
    }
}
