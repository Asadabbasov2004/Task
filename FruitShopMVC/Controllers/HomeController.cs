using FruitShopMVC.DAL;
using FruitShopMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FruitShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Fruit> fruitList = await _context.fruits.ToListAsync();
            return View(fruitList);
        }

      
    }
}
