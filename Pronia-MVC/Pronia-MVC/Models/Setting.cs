using System.ComponentModel.DataAnnotations;

namespace Pronia_MVC.Models
{
    public class Setting
    {
        public int Id { get; set; } 
        [StringLength(maximumLength: 15, ErrorMessage = "name should have 10 caharacters")]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
