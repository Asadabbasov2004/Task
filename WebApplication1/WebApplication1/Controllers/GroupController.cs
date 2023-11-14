using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
