using System.ComponentModel.DataAnnotations;

namespace FruitShopMVC.ViewModels
{
    public class CreateVm
    {
        public IFormFile? ImageUrl { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "must be at least 3 letters")]
        public string Header { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "must be at least 3 letters")]
        public string Name { get; set; }
    }
}
