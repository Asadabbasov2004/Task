using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Pronia_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public SliderController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            List<Slider> sliderList = _context.sliders.ToList();
            return View(sliderList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!slider.ImageFile.ContentType.Contains("image"))
            {
                ModelState.AddModelError("ImageFile", "Yalnizca Sekil yukluye bilersiz");
                return View();
            }
            if (slider.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "Maxsimum 2mb yukluye bilersiz!!");
                return View();
            }

            slider.ImgUrl = slider.ImageFile.Upload(_environment.WebRootPath, @"\Upload\SliderImage\");
            //string filname = slider.ImageFile.FileName;
            //if(filname.Length >64 )
            //{
            //    filname= filname.Substring(filname.Length-64);
            //}
            //filname=Guid.NewGuid().ToString()+filname;

            ////string path = @"C:\Users\rasul\OneDrive\Masaüstü\BB205_Pronia\BB205_Pronia\wwwroot\Upload\SliderImage\" +filname;
            ////string path = _environment.WebRootPath + @"\Upload\SliderImage\" + filname;
            //using (FileStream stream = new FileStream(path,FileMode.Create))
            //{
            //    slider.ImageFile.CopyTo(stream);
            //}






            if (!ModelState.IsValid)
            {
                return View();
            }
            await _context.sliders.AddAsync(slider);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var slider = _context.sliders.FirstOrDefault(s => s.Id == id);

            _context.sliders.Remove(slider);
            _context.SaveChanges();
            FileManager.DeleteFile(slider.ImgUrl, _environment.WebRootPath, @"\Upload\SliderImage\");
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id) {
            Slider slider = _context.sliders.Find(id);
            return View(slider);
        }
        [HttpPost]
       public IActionResult Update(Slider slider) {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Slider oldslider = _context.sliders.Find(slider.Id);
            oldslider.Title = slider.Title;
            oldslider.SubTitle = slider.SubTitle;
            oldslider.ImgUrl = slider.ImgUrl;
            oldslider.Description = slider.Description;
            _context.SaveChanges();

            return RedirectToAction("Update");
        }

    }
}
