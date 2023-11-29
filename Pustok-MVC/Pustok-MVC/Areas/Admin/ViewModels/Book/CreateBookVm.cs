namespace Pustok_MVC.Areas.Admin.ViewModels.Book
{
    public class CreateBookVm
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        //relation for Tag ,many to many
        public List<int>? TagIds { get; set; }

        //relation for BookImgs.many to one

        public int? BookImgsId { get; set; }
        //?multiplie img 


        //realtion for Author ,many to one
       public int? AuthorId { get; set; }

       //relation for Category ,many to one
       public int? CatagoryId { get; set; }


    }
}
