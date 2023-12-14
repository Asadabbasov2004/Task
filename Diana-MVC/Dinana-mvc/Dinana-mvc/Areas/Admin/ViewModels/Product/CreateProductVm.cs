using System.ComponentModel.DataAnnotations;

namespace Dinana_mvc.Areas.Admin.ViewModels.Product
{
    public class CreateProductVm 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public int? CategoryId { get; set; }
        public List<int> SizeIds {  get; set; }
        public List<int> MaterialIds { get; set; }
        public List<int> ColorIds { get; set; }

        [Required]
        public List<IFormFile> AllPhotos { get; set; }
        public IFormFile Mainphoto { get; set; }

    }
}
