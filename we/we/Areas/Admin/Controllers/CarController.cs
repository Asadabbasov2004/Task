using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace we.Areas.Admin.Controllers
{
	public class CarController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

	

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

	}
}
