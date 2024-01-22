using FruitShopMVC.DAL;
using FruitShopMVC.Helper;
using FruitShopMVC.Models;
using FruitShopMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FruitShopMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class FruitController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public FruitController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<ActionResult> Index()
        {
            IEnumerable<Fruit> fruitList = await _context.fruits.ToListAsync();
            return View(fruitList);
        }

      
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateVm createVm)
        {
            if (!ModelState.IsValid)
            {
                return View(createVm);
            }
            if (!createVm.Image.CheckType("image"))
            {
                ModelState.AddModelError("Image", "only image");
                return View(createVm);
            }
            if (!createVm.Image.CheckLength(3000))
            {
                ModelState.AddModelError("Image", "only image-3mb");
                return View(createVm);
            }
            Fruit fruit = new Fruit()
            {
                Name = createVm.Name,
                Header = createVm.Header,
                ImageUrl =createVm.Image.Upload(_env.WebRootPath,@"\Upload\Images")
            };
            await _context.fruits.AddAsync(fruit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Update(int id)
        {
            if (id <= 0) return BadRequest();
            Fruit fruit =await _context.fruits.Where(x=>x.Id==id).FirstOrDefaultAsync();
            if(fruit==null) return BadRequest();
            UpdateVm vm = new UpdateVm()
            {
                Name= fruit.Name,
                Header = fruit.Header,
                ImageUrl=fruit.ImageUrl
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Update(UpdateVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Fruit fruit = await _context.fruits.Where(x => x.Id == vm.Id).FirstOrDefaultAsync();
            if (!vm.Image.CheckType("image"))
            {
                ModelState.AddModelError("Image", "only image");
                return View(vm);
            }
            if (!vm.Image.CheckLength(3000))
            {
                ModelState.AddModelError("Image", "only image-3mb");
                return View(vm);
            }

            fruit.Header= vm.Header;
            fruit.Name= vm.Name;
            fruit.ImageUrl= vm.Image.Upload(_env.WebRootPath,@"\Upload\Images\");
           _context.fruits.Update(fruit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    
        public async Task<ActionResult> Delete(int id)
        {
            var fruit= _context.fruits.FirstOrDefault(y => y.Id == id);
             _context.fruits.Remove(fruit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
