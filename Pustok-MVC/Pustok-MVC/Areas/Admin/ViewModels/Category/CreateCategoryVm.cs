namespace Pustok_MVC.Areas.Admin.ViewModels.Category
{
    public class CreateCategoryVm
    {
        public string Name { get; set; }
        public int? CatagoryId { get; set; }
        //relation for blog ,many to one
        public ICollection<Blog>? blogs { get; set; }
        //relation for Book,many to one
        public List<Book>? books { get; set; }
    }
}
