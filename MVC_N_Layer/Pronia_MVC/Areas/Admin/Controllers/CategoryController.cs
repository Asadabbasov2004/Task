using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.Business.Services.Interface;
using Pronia.Core.Entities;
using Pronia.DAL.Context;

namespace Pronia_MVC.Areas.Admin.Controllers
{
        [Area("Admin")]
    public class CategoryController:Controller
    {
        private readonly ICategoryService _service;
        DbContext _context;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
      //  [Authorize(Roles = "Admin,Moderator")]
        public IActionResult Index()
        {
            var categories = _service.GetAllAsync();
            Console.WriteLine(typeof(Category));
            return View(categories);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        
        public IActionResult Create(Category category)
        {
            //_context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

      //  [Authorize(Roles = "Admin")]

        public IActionResult Delete(int id)
        {

            //Category category = _context.Categories.Find(id);
            //_context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //[Authorize(Roles = "Admin")]

        //public IActionResult Update(int id)
        //{
        //    Category category = _context.Categories.Find(id);
        //    return View(category);
        //}
        [HttpPost]
        ///[Authorize(Roles = "Admin")]

        public IActionResult Update(Category newcategory)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            //Category oldcategory = _context.Categories.Find(newcategory.Id);
            //oldcategory.Name = newcategory.Name;

            //_context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
