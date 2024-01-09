using Microsoft.AspNetCore.Mvc;

namespace AppBay.MVC.Areas.Admin.Controllers
{
	[Area("admin")]
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
