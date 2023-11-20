using Microsoft.AspNetCore.Mvc;

namespace MVC_relation_detail.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
