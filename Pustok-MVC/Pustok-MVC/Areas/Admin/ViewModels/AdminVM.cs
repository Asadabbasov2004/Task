using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pustok_MVC.Areas.Admin.ViewModels
{
    public class AdminVM
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set; } 


        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        public int? AuthorId { get; set; }
        public Author? Author { get; set; }
        public List<Book> books { get; set; }
        public List<BookImg>? BookImgs { get; set; }
        [NotMapped]
        public List<IFormFile> ImagesFiles { get; set; }
    }
}
