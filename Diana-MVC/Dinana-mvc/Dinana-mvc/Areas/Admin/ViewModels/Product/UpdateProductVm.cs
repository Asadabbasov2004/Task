using Microsoft.Build.Framework;

namespace Dinana_mvc.Areas.Admin.ViewModels.Product
{
    public class UpdateProductVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double  Price { get; set; }
        public int? Count { get; set; }
        public int? CategoryId { get; set; }
        public List<int>? SizeIds { get; set; }
        public List<int>? MaterialIds { get; set; }
        public List<int>? ColorIds { get; set; }

        public List<int> ImageIds { get; set; }
        public List<UpdateImagesVm> Images { get; set; }
        [Required]
        public List<IFormFile>? AllPhotos { get; set; }
        public IFormFile? Mainphoto { get; set; }
    }
    public class UpdateImagesVm
    {
        public int? Id { get; set; }
        public string? ImageUrl { get; set; }
        public string? IsActive { get; set; }

    }
   



}
