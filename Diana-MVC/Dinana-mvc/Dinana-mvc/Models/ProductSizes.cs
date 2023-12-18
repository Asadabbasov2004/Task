namespace Dinana_mvc.Models
{
    public class ProductSizes:BaseEntity
    {
        public bool? IsActive { get; set; }
        public int SizeId;
        public Size? Size;
        public int ProductId;
        public Product? Product;
    }
}
