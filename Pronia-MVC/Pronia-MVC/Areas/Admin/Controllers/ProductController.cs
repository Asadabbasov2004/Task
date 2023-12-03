using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_MVC.Areas.Admin.ViewModels.Product;

namespace BB205_Pronia.Areas.Manage.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        AppDbContext _db { get; set; }
        IWebHostEnvironment _webHostEnvironment { get; set; }
        public ProductController(AppDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;

        }


        public async Task<IActionResult> Index()
        {
            List<Product> products = await _db.Products.Include(p => p.Category)
                .Include(p => p.ProductTags).ThenInclude(pt => pt.Tag).Include(p => p.ProductImages)
                .ToListAsync();
            return View(products);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Tags = await _db.Tags.ToListAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVm createProductVm)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Tags = await _db.Tags.ToListAsync();
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool result = await _db.Categories.AnyAsync(c => c.Id == createProductVm.CategoryId);
            if (!result)
            {
                ModelState.AddModelError("CategoryId", "Bele category movcuud deyil");
            }
            Product product = new Product()
            {
                Name = createProductVm.Name,
                Price = createProductVm.Price,
                Description = createProductVm.Description,
                Sku = createProductVm.SKU,
                CategoryId = createProductVm.CategoryId,
                ProductImages = new List<ProductImages>(),
                //ProductTags =new List<ProductTag>()
            };

            if (createProductVm.TagIds != null)
            {
                foreach (int tagId in createProductVm.TagIds)
                {
                    bool resultTag = await _db.Tags.AnyAsync(c => c.Id == tagId);
                    if (!resultTag)
                    {
                        ModelState.AddModelError("TagIds", $"{tagId}-idli tag movcuud deyil");
                        return View();
                    }

                    ProductTag productTag = new ProductTag()
                    {
                        Product = product,
                        TagId = tagId

                    };

                    _db.ProductTags.Add(productTag);

                }
            }

            if (!createProductVm.MainPhoto.CheckType("image/"))
            {
                ModelState.AddModelError("MainPhoto", "Duzgun format (sekil) deyil \t");
                return View();
            }
            if (!createProductVm.MainPhoto.CheckLength(3000))
            {
                ModelState.AddModelError("MainPhoto", "max 3mb sekil ola biler \t");
                return View();
            }

            if (!createProductVm.HoverPhoto.CheckType("image/"))
            {
                ModelState.AddModelError("HoverPhoto", "Duzgun format (sekil) deyil");
            }
            if (!createProductVm.HoverPhoto.CheckLength(3000))
            {
                ModelState.AddModelError("HoverPhoto", "max 3mb sekil ola biler");
                return View();
            }

            ProductImages mainImages = new ProductImages()
            {
                IsPrime = true,
                Url = createProductVm.MainPhoto.Upload(_webHostEnvironment.WebRootPath, @"\Upload\Product\"),
                Product = product,
            };

            ProductImages hoverImages = new ProductImages()
            {
                IsPrime = false,
                Url = createProductVm.HoverPhoto.Upload(_webHostEnvironment.WebRootPath, @"\Upload\Product\"),
                Product = product,
            };
            product.ProductImages.Add(mainImages);
            product.ProductImages.Add(hoverImages);
            TempData["Error"] = "";
            if (createProductVm.Photos != null)
            {
                foreach (var photo in createProductVm.Photos)
                {
                    if (!photo.CheckType("image/"))
                    {
                        TempData["Error"] += $"{photo.FileName} -duzgun format deyil";
                        continue;
                    }
                    if (!photo.CheckLength(3000))
                    {
                        TempData["Error"] += $"{photo.FileName} - 3mb dan boyuk olmaz";
                        continue;
                    }
                    ProductImages newPhoto = new ProductImages()
                    {
                        IsPrime = null,
                        Url = photo.Upload(_webHostEnvironment.WebRootPath, @"\Upload\Product\"),
                        Product = product,
                    };
                    product.ProductImages.Add(newPhoto);
                }
            }
            //await _db.ProductImages.AddAsync()
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            Product product = await _db.Products.Include(p => p.Category)
                .Include(p => p.ProductTags)
                .ThenInclude(p => p.Tag)
                .Where(p => p.Id == id).FirstOrDefaultAsync();
            if (product == null)
            {
                return View("Error");
            }
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Tags = await _db.Tags.ToListAsync();
            UpdateProductVm updateProductVm = new UpdateProductVm()
            {
                Id = id,
                Name = product.Name,
                Description = product.Description,
                SKU = product.Sku,
                CategoryId = product.CategoryId,
                TagIds = new List<int>()
            };

            foreach (var item in product.ProductTags)
            {
                updateProductVm.TagIds.Add(item.TagId);
            }
            return View(updateProductVm);
        }



        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductVm updateProductVm)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Tags = await _db.Tags.ToListAsync();
            if (!ModelState.IsValid)
            {

                return View("Error");
            }
            Product existProduct = await _db.Products.Where(p => p.Id == updateProductVm.Id).FirstOrDefaultAsync();
            if (existProduct == null)
            {
                return View("Error");
            }
            bool result = await _db.Categories.AnyAsync(c => c.Id == updateProductVm.CategoryId);
            if (!result)
            {
                ModelState.AddModelError("CategoryId", "Bele category movcuud deyil");
            }
            existProduct.Name = updateProductVm.Name;
            existProduct.Description = updateProductVm.Description;
            existProduct.Price = updateProductVm.Price;
            existProduct.Sku = updateProductVm.SKU;
            existProduct.CategoryId = updateProductVm.CategoryId;

            if (updateProductVm.TagIds != null)
            {
                foreach (int tagId in updateProductVm.TagIds)
                {
                    bool resultTag = await _db.Tags.AnyAsync(c => c.Id == tagId);
                    if (!resultTag)
                    {
                        ModelState.AddModelError("TagIds", $"{tagId}-idli tag movcuud deyil");
                        return View();
                    }
                }
                List<int> createTags;
                if (existProduct.ProductTags != null)
                {
                    createTags = updateProductVm.TagIds.Where(ti => !existProduct.ProductTags.Exists(pt => pt.TagId == ti)).ToList();

                }
                else
                {
                    createTags = updateProductVm.TagIds.ToList();
                }

                foreach (int tagId in createTags)
                {
                    ProductTag productTag = new ProductTag()
                    {
                        TagId = tagId,
                        ProductId = existProduct.Id
                    };
                    await _db.ProductTags.AddAsync(productTag);
                }

                List<ProductTag> removeTags = existProduct.ProductTags.Where(pt => !updateProductVm.TagIds.Contains(pt.TagId)).ToList();
                _db.ProductTags.RemoveRange(removeTags);
            }
            else
            {
                //existProduct.ProductTags =new List<ProductTag>();
                var productTagList = _db.ProductTags.Where(pt => pt.ProductId == existProduct.Id).ToList();
                _db.ProductTags.RemoveRange(productTagList);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return View("Error");
            }
            _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
