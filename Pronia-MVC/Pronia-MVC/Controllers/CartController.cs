using Newtonsoft.Json;

namespace Pronia_MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddBasket(int id)
        {
            if (id <= 0) return BadRequest();

            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            List<BasketCookieItemVm> basket;
            var json = Request.Cookies["Basket"];

            if (json != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketCookieItemVm>>(json);
                var existProduct = basket.FirstOrDefault(p => p.Id == id);
                if (existProduct != null)
                {
                    existProduct.Count += 1;
                }
                else
                {
                    basket.Add(new BasketCookieItemVm()
                    {
                        Id = id,
                        Count = 1
                    });
                }
            }
            else
            {
                basket = new List<BasketCookieItemVm>();
                basket.Add(new BasketCookieItemVm()
                {
                    Id = id,
                    Count = 1
                });
            }

            var cookieBasket = JsonConvert.SerializeObject(basket);
            Response.Cookies.Append("Basket", cookieBasket); // Burada "json" yerine "cookieBasket" kullanılmalı

            return RedirectToAction(nameof(Index), "Home");
        }


        public IActionResult GetBasket()
        {
            var basketCookieJson = Request.Cookies["Basket"];
            return Json(basketCookieJson);
        }
    }
}
