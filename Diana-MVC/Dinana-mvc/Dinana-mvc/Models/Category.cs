namespace Dinana_mvc.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
