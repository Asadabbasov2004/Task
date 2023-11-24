using System.ComponentModel.DataAnnotations.Schema;

namespace Pustok_MVC.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        public int? AuthorId { get; set; }
        public Author? Author { get; set; }

        public List<BookImg>? BookImgs { get; set; }
        [NotMapped]
        public List <IFormFile> ImagesFiles { get; set; }
    }
}
