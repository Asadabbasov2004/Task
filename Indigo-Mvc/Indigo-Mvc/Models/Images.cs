namespace Indigo_Mvc.Models
{
    public class Images:BaseEntity
    {
        public string Url { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }

    }
}
