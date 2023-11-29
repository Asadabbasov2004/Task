namespace Pustok_MVC.Models
{
    public class BlogImgs
    {
        public int Id { get; set; }
        public string Url { get; set; }

        //relation for Blog ,many to one
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
