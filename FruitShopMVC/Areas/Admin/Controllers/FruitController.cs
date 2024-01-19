using FruitShopMVC.DAL;
using FruitShopMVC.Models;
using FruitShopMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FruitShopMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FruitController : Controller
    {
        private readonly AppDbContext _context;

        public FruitController(AppDbContext context)
        {
            _context = context;
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
            Fruit fruit= new Fruit()
            {
                Name = createVm.Name,
                Header = createVm.Header,
                ImageUrl =createVm.ImageUrl
            };
            await _context.fruits.AddAsync(fruit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var fruit =_context.fruits.FirstOrDefault(x => x.Id == id);
            UpdateVm vm = new UpdateVm()
            {
                Id = id,
                Name = fruit.Name,
                Header = fruit.Header,
                ImageUrl = fruit.ImageUrl,
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
            Fruit updated =await _context.fruits.FirstOrDefaultAsync(x => x.Id == vm.Id);
            updated.Name =vm.Name;
            updated.Header = vm.Header;
            updated.ImageUrl = vm.ImageUrl;
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
