namespace Pustok_MVC.Areas.Admin.ViewModels.Book
{
    public class CreateBookVm
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

       public int? AuthorId { get; set; }
       // public int CategoryIds { get; set; }
    }
}
