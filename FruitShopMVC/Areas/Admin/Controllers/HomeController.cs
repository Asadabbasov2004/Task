using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitShopMVC.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
