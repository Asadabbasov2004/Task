namespace Pustok_MVC.Models
{
    public class Catagory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CatagoryId { get; set; }
        
        //relation for blog ,many to one
        public List<Blog>? blogs { get; set; }
        //relation for Book,many to one
        public List<Book> books { get; set; }
    }
}
