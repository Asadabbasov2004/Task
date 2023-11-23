namespace Pustok_MVC.Models
{
    public class BookImg
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
