using Pustok_MVC.Models;

namespace Pustok_MVC.ViewModels
{
    public class HomeVM
    {
        public List<Slider> sliders { get; set; }
        public List<Catagory> catagories {get; set; }
        public List<Book> books { get; set; }
    }
}
