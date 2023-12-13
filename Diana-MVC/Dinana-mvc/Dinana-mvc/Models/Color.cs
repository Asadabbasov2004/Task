namespace Dinana_mvc.Models
{
    public class Color : BaseEntity
    {
        public string Name { get; set; }
        public List<ProductColor> Colors { get; set; }
    }
}
