using FrontToBackMVC_2.DAL;
using FrontToBackMVC_2.Models;
using FrontToBackMVC_2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBackMVC_2.Controllers
{
    public class WorkController : Controller
    {
        AppDbContext _context;
        public WorkController(AppDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            List <Work> works=_context.Works.ToList();
            List<Catagory> catagories=_context.Catagories.ToList();
            List<WorkImage> images=_context.Images.ToList();

            WorkVM workVM = new WorkVM();
            workVM.Works = works;
            workVM.Catagories = catagories;
            workVM.Images = images;

            return View(workVM);
        }
    }
}
