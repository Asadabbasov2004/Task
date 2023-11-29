namespace Pustok_MVC.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<BookTags>? bookTags { get; set; }
        public List<BlogTag>? blogTags { get; set; }
    }
}
