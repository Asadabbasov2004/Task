﻿using Microsoft.AspNetCore.Mvc;

namespace Pronia_MVC.Controllers
{
    public class ShopController : Controller
    {
        AppDbContext _db;

        public ShopController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Detail(int? id)
        {
            Product product = _db.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductTags)
                .ThenInclude(pt => pt.Tag)
                .FirstOrDefault(product => product.Id == id);


            return View(product);
        }
    }
}
