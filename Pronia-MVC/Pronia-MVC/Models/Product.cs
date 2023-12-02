namespace Pronia_MVC.Models
{
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public double Price { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<ProductTag>? ProductTags { get; set; }
        public List<ProductImages>? ProductImages { get; set; }

    }
}
