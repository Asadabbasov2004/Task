using Maxim.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Maxim.Models
{
    public class Service:BaseEntity
    {
        [Required(ErrorMessage = "Required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Minium 3 ,Maximum 30 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(400, MinimumLength = 3, ErrorMessage = "Minium 3 ,Maximum 400 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Minium 3 ,Maximum 60 characters")]
        public string IconUrl { get; set; }
    }
}
