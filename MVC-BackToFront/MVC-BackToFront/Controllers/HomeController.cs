using Microsoft.AspNetCore.Mvc;
using MVC_BackToFront.Models;
using MVC_BackToFront.ViewModels;

namespace MVC_BackToFront.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List <Products> productsList = new List<Products>();
            productsList.Add(new Products()
            {
                Id = 1,
                Title="First clothes",
                Price="22,39$",
                Gender ="men",
                ImageUrl="men-01.jpg"

            });
            productsList.Add(new Products()
            {
                Id = 2,
                Title = "Second clothes",
                Price = "12,99$",
                Gender = "men",
                ImageUrl = "men-03.jpg"

            }); 
            productsList.Add(new Products()
            {
                Id = 3,
                Title = "Third clothes",
                Price = "39,99$",
                Gender = "men",
                ImageUrl = "men-02.jpg"

            }); 
            productsList.Add(new Products()
            {
                Id = 4,
                Title = "4 clothes",
                Price = "29,99$",
                Gender = "men",
                ImageUrl = "men-02.jpg"

            });
            productsList.Add(new Products()
            {
                Id = 5,
                Title = "First women's clothes",
                Price = "29,99$",
                Gender = "women",
                ImageUrl = "women-01.jpg"
            });

            productsList.Add(new Products()
            {
                Id = 6,
                Title = "2nd women's dresses",
                Price = "19,99$",
                Gender = "women",
                ImageUrl = "women-02.jpg"
            });
            productsList.Add(new Products()
            {
                Id = 7,
                Title = "Third women's dresses",
                Price = "59,99$",
                Gender = "women",
                ImageUrl = "women-03.jpg"
            });
            productsList.Add(new Products()
            {
                Id = 8,
                Title = "Third women's dresses",
                Price = "59,99$",
                Gender = "women",
                ImageUrl = "women-01.jpg"
            });
            productsList.Add(new Products()
            {
                Id = 9,
                Title = "First kids's clothes",
                Price = "9,99$",
                Gender = "kids",
                ImageUrl = "kid-01.jpg"
            }); productsList.Add(new Products()
            {
                Id = 10,
                Title = "Second kids's clothes",
                Price = "12,99$",
                Gender = "kids",
                ImageUrl = "kid-02.jpg"
            });
            productsList.Add(new Products()
            {
                Id = 11,
                Title = "third kids's clothes",
                Price = "29,99$",
                Gender = "kids",
                ImageUrl = "kid-03.jpg"
            });
            productsList.Add(new Products()
            {
                Id = 12,
                Title = "4th kids's clothes",
                Price = "129,99$",
                Gender = "kids",
                ImageUrl = "kid-01.jpg"
            });
            HomeVM homeVM = new HomeVM();
            homeVM.productsListMen = productsList.Where(x => x.Gender == "men").Take(4).ToList();
            homeVM.productsListWomen = productsList.Where(x => x.Gender == "women").Take(4).ToList();
            homeVM.productsListKids = productsList.Where(x => x.Gender == "kids").Take(4).ToList();
            return View(homeVM);

        }
        public IActionResult Get(HomeVM model)
        {
            return View(model);
        }

    }
}
