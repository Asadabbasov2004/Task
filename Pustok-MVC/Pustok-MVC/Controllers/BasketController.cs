using Microsoft.AspNetCore.Mvc;

namespace Pustok_MVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        public BasketController(AppDbContext context)
        {
            _context = context;   
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task< IActionResult> AddItem(int id)
        {
            if(id<=0 || id == null)
            {
                return BadRequest();
            }
            Book book = await _context.books.Include(p=>p.BookImgs).
            return View();
        }
        public IActionResult RemoveItem() { 
        return View();
        }
        public IActionResult GetAllItems()
        {
            return View();
        }
        public IActionResult RemoveAllItems() {
            return View();
        }
    }
}
