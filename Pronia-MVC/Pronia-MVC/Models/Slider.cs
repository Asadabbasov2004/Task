using System.ComponentModel.DataAnnotations;

namespace Pronia_MVC.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required,MinLength(3,ErrorMessage = "The number must be greater than minimum 3")]
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public string? ImgUrl {  get; set; }
    }
}

