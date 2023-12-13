namespace Dinana_mvc.Models
{
    public class Material:BaseEntity
    {
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public List<ProductMaterial> Materials { get; set; }
    }
}
