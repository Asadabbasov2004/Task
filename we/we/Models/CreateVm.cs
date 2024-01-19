using System.ComponentModel.DataAnnotations;

namespace we.Models
{
	public class CreateVm
	{
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
        [Required(ErrorMessage = "Required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Maximum 30 characters")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Features { get; set; }
        [Required]
        public string ImgUrl { get; set; }
    }
}
