using System.ComponentModel.DataAnnotations;

namespace FruitShopMVC.ViewModels
{
    public class UpdateVm
    {
        public int Id { get; set; } 
        [Required]
        [MinLength(3, ErrorMessage = "must be at least 3 letters")]
        public string Header { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "must be at least 3 letters")]
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
    }
}
