using FrontToBackMVC_2.DAL;
using FrontToBackMVC_2.Models;
using FrontToBackMVC_2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FrontToBackMVC_2.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            List<Sliders> slidersList = _context.Sliders.ToList();
            List<Work> workList = _context.Works.ToList();
            /*slidersList.Add(new Sliders()
             {
                 Title = "Develop <strong>Strategies</strong> for\r\n                                <br>your business",
                 Description= "Purple Buzz is a corporate HTML template with Bootstrap 5 Beta 1. This CSS template is 100% free to download provided by <a rel=\"nofollow\" href=\"https://templatemo.com/page/1\" target=\"_parent\">TemplateMo</a>. Total 6 HTML pages included in this template. Icon fonts by <a rel=\"nofollow\" href=\"https://boxicons.com/\" target=\"_blank\">Boxicons</a>. Photos are from <a rel=\"nofollow\" href=\"https://unsplash.com/\" target=\"_blank\">Unsplash</a> and <a rel=\"nofollow\" href=\"https://icons8.com/\" target=\"_blank\">Icons 8</a>."
             }); 
             slidersList.Add(new Sliders()
             {
                 Title = "HTML CSS Template with Bootstrap 5 Beta 1",
                 Description = "You are not allowed to re-distribute this Purple Buzz HTML template as a downloadable ZIP file on any kind of Free CSS collection websites. This is strongly prohibited. Please contact TemplateMo for more information."
             }); 
             slidersList.Add(new Sliders()
             {
                 Title = "Cupidatat non proident, sunt in culpa qui officia",
                 Description = "Ut enim ad minim veniam, quis nostrud exercitation ullamco\r\n   laboris nisi ut aliquip ex ea commodo consequat. Duis aute\r\n  irure dolor in reprehenderit in voluptate velit esse cillum\r\n                                dolore eu fugiat nulla pariatur. Excepteur sint occaecat."
             });*/

            //_context.AddRange(slidersList);
            //_context.SaveChanges();

            workList.Add(new Work()
            {
               Title="",
               Description="",
               ImgUrl="",
               CreatedDate=DateTime.Now,

            });
            workList.Add(new Work()
            {
                Title = "",
                Description = "",
                ImgUrl = "",
                CreatedDate = DateTime.Now,

            });
            workList.Add(new Work()
            {
                Title = "",
                Description = "",
                ImgUrl = "",
                CreatedDate = DateTime.Now,

            });



            HomeVM homeVM = new HomeVM();
            homeVM.Sliders = slidersList;
            homeVM.Works= workList;
            return View(homeVM);
        }
        //public IActionResult Get(List<Sliders> slidersList )
        //{
        //    return View(model);
        //}
    }
}
