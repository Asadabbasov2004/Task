namespace Pustok_MVC.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Book> books { get; set; }
    }
}
