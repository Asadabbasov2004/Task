using System.ComponentModel.DataAnnotations;

namespace Pronia_MVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 40, ErrorMessage = "Uzunlugu astiniz")]
        public string Name { get; set; }
        public List <Product>? Products { get; set; }
    }
}
