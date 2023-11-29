namespace Pustok_MVC.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        //relation for Book ,many to one
        public List<Book> books { get; set; }
    }
}
