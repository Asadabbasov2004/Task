namespace Indigo_Mvc.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public List<Images>? Images { get; set; }

    }
}
