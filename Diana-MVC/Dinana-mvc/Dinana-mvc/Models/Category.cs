namespace Dinana_mvc.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public List<Product>? Products { get; set;}
    }
}
