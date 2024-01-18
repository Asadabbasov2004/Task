using FruitShopMVC.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace FruitShopMVC.Models
{
    public class Fruit:BaseEntity
    {
        [Required]
        [MinLength(3, ErrorMessage = "must be at least 3 letters")]
        public string Header { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "must be at least 3 letters")]
        public string Name { get; set; }
        public string? ImageUrl { get; set; }

    }
}
