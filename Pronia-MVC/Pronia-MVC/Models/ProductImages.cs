namespace Pronia_MVC.Models
{
    public class ProductImages
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool? IsPrime { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
