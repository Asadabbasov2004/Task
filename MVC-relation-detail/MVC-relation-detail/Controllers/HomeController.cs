using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_relation_detail.DAL;
using MVC_relation_detail.ViewModals;

namespace MVC_relation_detail.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //List<Catagory> catagories =_context.Catagories.ToList();
            //List <Food> foodList = _context.Foods.ToList();
            //List <FoodImg> foodImgs = _context.FoodImgs.ToList();
            //HomeVM homeVM = new HomeVM();
            //homeVM.foods =foodList;
            //homeVM.foodImgs =foodImgs;

            var foodWithImage = _context.Foods
                .Include(x => x.Catagory)
                .Include(x => x.Images) 
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Title,
                    x.Description,
                    CategoryName = x.Catagory.Title,
                    FirstImageUrl = x.Images.FirstOrDefault().Url
                })
                .ToList();
            return View(foodWithImage);
        }
    }
}
