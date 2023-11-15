using MVC_BackToFront.Models;

namespace MVC_BackToFront.ViewModels
{
    public class HomeVM
    {

        public List<Products> productsListMen { get; set; }
        public List<Products> productsListWomen { get; set; }
        public List<Products> productsListKids { get; set; }
    }
}
