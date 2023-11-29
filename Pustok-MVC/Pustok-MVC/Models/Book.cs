using System.ComponentModel.DataAnnotations.Schema;

namespace Pustok_MVC.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        //relation for Author,many to one
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }


        //relation for Category ,many to one
        public int CatagoryId { get; set; }
        public Catagory? Catagory { get; set; }


        //relation for Tag , many to many
        public List<BookTags>? bookTags { get; set; }

        //relation for BookImage ,many to one 
        public List<BookImg>? BookImgs { get; set; }
        //[NotMapped]
      //  public List <IFormFile> ImagesFiles { get; set; }


    }
}
