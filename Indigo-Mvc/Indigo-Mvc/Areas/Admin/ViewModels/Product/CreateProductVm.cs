

namespace Indigo_Mvc.Areas.Admin.ViewModels.Product
{
    public class CreateProductVm
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        [Required]
        public List<IFormFile> AllPhotos { get; set; }
    }
}
