using Dinana_mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dinana_mvc.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _db;
        public async Task<IActionResult> Index()
        {
            //HomeVm homeVm = new HomeVm()
            //{
            //    Products = await _db.Products.Include(p => p.Images).Include(p => p.Categories)
            //    .Include(p => p.ProductColors).ThenInclude(p=>p.Color)
            //    .Include(p=>p.ProductMaterials).ThenInclude(p=>p.Material)
            //    .Include(p=>p.ProductSizes).ThenInclude(p=>p.Size)
            //    .ToListAsync()
            //};


            return View();
        }
    }
}
