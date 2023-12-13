namespace Dinana_mvc.Models
{
    public class Size : BaseEntity
    {
        public string Sizes { get; set; }
        public List<ProductSizes> ProductSizes { get; set; }
    }
}
