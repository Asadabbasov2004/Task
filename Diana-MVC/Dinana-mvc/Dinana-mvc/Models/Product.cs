
namespace Dinana_mvc.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price {get; set; }
        public int? Count { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<productImages>? Images { get; set; }
        public List<ProductSizes>? ProductSizes { get; set; }
        public List<ProductMaterial>? ProductMaterials { get; set; }
        public List<Category>? Categories { get; set; }
        public List<ProductColor>? ProductColors { get; set; }
    }
}
