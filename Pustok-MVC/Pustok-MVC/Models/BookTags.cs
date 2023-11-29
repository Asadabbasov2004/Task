namespace Pustok_MVC.Models
{
    public class BookTags
    {
        public int Id { get; set; }

        //relation table for book ,blog
        public int BookId { get; set; }
        public int TagId {  get; set; }
        public Book? Book { get; set; }
        public Tag? Tag { get; set; }
    }
}
