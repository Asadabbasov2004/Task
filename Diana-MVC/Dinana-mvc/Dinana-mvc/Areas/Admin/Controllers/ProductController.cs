using Dinana_mvc.Areas.Admin.ViewModels.Product;
using Dinana_mvc.Helpers;
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

        public async Task<IActionResult> Index()
        {
            List<Product> products = await _db.Products.Include(p => p.Images).Include(p => p.Category)
                .Include(p => p.ProductColors).ThenInclude(p => p.Color)
                .Include(p => p.ProductMaterials).ThenInclude(p => p.Material)
                .Include(p => p.ProductSizes).ThenInclude(p => p.Size)
                .Include(p => p.Images)
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
                Count = createProductVm.Count,
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
                        Product = product,
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
            var existingProduct = await _db.Products
                .Include(p => p.Images)
                .Include(p => p.ProductSizes)
                .Include(p => p.ProductColors)
                .Include(p => p.ProductMaterials)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (existingProduct == null)
            {
                return View();
            }
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Colors = await _db.Colors.ToListAsync();
            ViewBag.Materials = await _db.Materials.ToListAsync();
            ViewBag.Sizes = await _db.Sizes.ToListAsync();
            var updateProductVm = new UpdateProductVm
            {
                Id = existingProduct.Id,
                Name = existingProduct.Name,
                Description = existingProduct.Description,
                Price = existingProduct.Price,
                CategoryId = existingProduct.CategoryId,
                SizeIds = new List<int>(),
                MaterialIds = new List<int>(),
                ColorIds = new List<int>(),
                Images = new List<UpdateImagesVm>()
            };
            if (existingProduct.ProductSizes != null)
            {
                foreach (var item in existingProduct.ProductSizes)
                {
                    updateProductVm.SizeIds.Add(item.SizeId);
                }
            }
            if (existingProduct.ProductMaterials != null)
            {
                foreach (var item in existingProduct.ProductMaterials)
                {
                    updateProductVm.MaterialIds.Add(item.MaterialId);
                }
            }
            if (existingProduct.ProductColors != null)
            {
                foreach (var item in existingProduct.ProductColors)
                {
                    updateProductVm.ColorIds.Add(item.ColorId);
                }
            }

            foreach (var item in existingProduct.Images)
            {
                UpdateImagesVm updateImagesVm = new UpdateImagesVm()
                {
                    Id = item.Id,
                    ImageUrl = item.ImageUrl,
                    IsActive = item.IsActive,
                };
                if (updateImagesVm == null)
                {
                    return View();
                }
                if (updateImagesVm != null)
                {
                    updateProductVm.Images.Add(updateImagesVm);
                }
            }

            return View(updateProductVm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductVm updateProductVm)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Colors = await _db.Colors.ToListAsync();
            ViewBag.Materials = await _db.Materials.ToListAsync();
            ViewBag.Sizes = await _db.Sizes.ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            Product existProduct = await _db.Products.Include(p => p.Images)
                .Include(p => p.ProductSizes)
                .Include(p => p.ProductColors)
                .Include(p => p.ProductMaterials)
                .FirstOrDefaultAsync(p => p.Id == updateProductVm.Id);

            if (existProduct == null)
            {
                return NotFound();
            }

            existProduct.Name = updateProductVm.Name;
            existProduct.Description = updateProductVm.Description;
            existProduct.Price = updateProductVm.Price;
            existProduct.Count = updateProductVm.Count;
            existProduct.CategoryId = updateProductVm.CategoryId;

            if (updateProductVm.SizeIds != null)
            {
                foreach (var item in updateProductVm.SizeIds)
                {
                    bool resultSize = await _db.ProductSizes.AnyAsync(c => c.Id == item);
                    if (!resultSize)
                    {
                        ModelState.AddModelError("SizeIds", "bele size yoxdu");
                        return View();
                    }
                }
                List<int> createSizeIds;
                if (existProduct.ProductSizes != null)
                {
                    createSizeIds = updateProductVm.SizeIds.Where(p => !existProduct.ProductSizes.Exists(pi => pi.SizeId == p)).ToList();
                }
                else
                {
                    createSizeIds = updateProductVm.SizeIds.ToList();
                }

                foreach (var sizeId in createSizeIds)
                {
                    ProductSizes productSizes = new ProductSizes()
                    {
                        SizeId = sizeId,
                        ProductId = existProduct.Id,
                    };
                    await _db.ProductSizes.AddAsync(productSizes);
                }

                List<ProductSizes> removeSizes = existProduct.ProductSizes.Where(p => !updateProductVm.SizeIds.Contains(p.SizeId)).ToList();
                _db.ProductSizes.RemoveRange(removeSizes);
            }
            else
            {
                var productSizes = _db.ProductSizes.Where(p => p.SizeId == existProduct.Id).ToList();
                _db.ProductSizes.RemoveRange(productSizes);
            }

            TempData["Error"] = "";

            //       Mainphoto

            if (updateProductVm.Mainphoto != null)
            {
                if (!updateProductVm.Mainphoto.CheckType("image/"))
                {
                    ModelState.AddModelError("MainPhoto", "ancaq sekil ola biler");
                    return View();
                }
                if (updateProductVm.Mainphoto.CheckLength(3000))
                {
                    ModelState.AddModelError("MainPhoto", "3mb dan boyuk olmaz");
                    return View();
                }

                var oldPhoto = existProduct.Images?.FirstOrDefault(p => p.IsActive == true);
                existProduct.Images?.Remove(oldPhoto);
                productImages newproductimage = new productImages()
                {
                    IsActive = true,
                    ProductId = existProduct.Id,
                    ImageUrl = updateProductVm.Mainphoto.UploadFile(_env.WebRootPath, @"\Upload\Product\")


                };
                existProduct.Images?.Add(newproductimage);
            }

            //all additional photos

            if (updateProductVm.AllPhotos != null)
            {
                foreach (var photo in updateProductVm.AllPhotos)
                {
                    if (!photo.CheckType("image/"))
                    {
                        TempData["Error"] += $"{photo.FileName} ancaq sekil ola biler\t";
                        continue;

                    }
                    if (photo.CheckLength(3000))
                    {
                        TempData["Error"] += $"{photo.FileName} 3mb dan boyuk olmaz";

                        continue;
                    }

                    productImages multipleimage = new productImages()
                    {

                        IsActive = false,
                        ImageUrl = photo.UploadFile(_env.WebRootPath, @"\Upload\Product\"),
                        Product = existProduct
                    };
                    existProduct.Images?.Add(multipleimage);

                }
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task< IActionResult> Delete(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            var relatedSize = _db.ProductSizes.Where(p => p.ProductId == id);
            var relatedMeterial =_db.ProductMaterials.Where(p => p.ProductId == id);    
            var relatedColor =_db.ProductColors.Where(p => p.ProductId == id);
            var relatedImage = _db.Images.Where(p => p.ProductId == id);
            var relatedCatwgory =_db.Categories.Where(p => p.ProductId ==id);

            _db.ProductSizes.RemoveRange(relatedSize);
            _db.ProductMaterials.RemoveRange(relatedMeterial);
            _db.ProductColors.RemoveRange(relatedColor);
            _db.Images.RemoveRange(relatedImage);
            _db.Categories.RemoveRange(relatedCatwgory);

            if (product == null)
            {
                return NotFound();
            }
            _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("index");
        }



    }
}
