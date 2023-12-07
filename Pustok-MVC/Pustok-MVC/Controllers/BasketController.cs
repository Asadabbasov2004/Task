using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            var jsonCookie = Request.Cookies["Basket"];
            List<BasketItemVm> basketItems = new List<BasketItemVm>();
            if (jsonCookie != null)
            {
                var cookieItems = JsonConvert.DeserializeObject<List<CookieItemsVm>>(jsonCookie);
                bool countCheck = false;
                List<CookieItemsVm> deletedCookies = new List<CookieItemsVm>();
                foreach (var item in cookieItems)
                {
                    Book book = _context.books.Where(p => p.IsDeleted == false).Include(p => p.BookImgs.Where(p => p.IsPrime == true)).FirstOrDefault(p => p.Id == item.Id);
                    if (book == null)
                    {
                        deletedCookies.Add(item);
                        continue;
                    }

                    basketItems.Add(
                        new BasketItemVm()
                        {
                            Id = item.Id,
                            Name = book.Name,
                            Price = book.Price,
                            Count = item.Count,
                            ImgUrl = book.BookImgs.FirstOrDefault().Url

                        }
                        );
                }
                if (deletedCookies.Count > 0)
                {
                    foreach (var cookie in deletedCookies)
                    {
                        cookieItems.Remove(cookie);
                    }
                    Response.Cookies.Append("Basket", JsonConvert.SerializeObject(cookieItems));
                }
            }
            return View(basketItems);
        }
        public async Task<IActionResult> AddBasket(int Id)
        {
            if (Id <= 0) return BadRequest();
            Book book = _context.books.Where(p => p.IsDeleted == false).FirstOrDefault(p => p.Id == Id);
            if (book == null) { return NotFound(); }
            List<CookieItemsVm> basket;
            var json = Request.Cookies["Basket"];

            if (json != null)
            {
                basket = JsonConvert.DeserializeObject<List<CookieItemsVm>>(json);
                var existProduct = basket.FirstOrDefault(p => p.Id == Id);
                if (existProduct != null)
                {
                    existProduct.Count += 1;
                }
                else
                {
                    basket.Add(new CookieItemsVm()
                    {
                        Id = Id,
                        Count = 1
                    }
                        );
                }
            }
            else
            {
                basket = new List<CookieItemsVm>();
                basket.Add(new CookieItemsVm()
                {
                    Id= Id,
                    Count = 1
                });

            }
            var CookiBasket =JsonConvert.SerializeObject(basket);
            Response.Cookies.Append("Basket", CookiBasket);


            return RedirectToAction(nameof(Index),"Home");
        }
        public IActionResult RemoveItem(int id)
        {
            var cookieBasket = Request.Cookies["Basket"];
            if(cookieBasket != null)
            {
                List<CookieItemsVm> basket =JsonConvert.DeserializeObject<List<CookieItemsVm>>(cookieBasket);
                var deleteElement =basket.FirstOrDefault(p => p.Id == id);
                if (deleteElement != null)
                {
                    basket.Remove(deleteElement);
                }

                Response.Cookies.Append("Basket", JsonConvert.SerializeObject(basket));
                return Ok();
            }

            return NotFound();
        }
        public IActionResult GetAllItems()
        {

            return View();
        }
        public IActionResult RemoveAllItems()
        {
            return View();
        }
    }
}
