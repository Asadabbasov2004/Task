namespace Dinana_mvc.Models
{
    public class productImages:BaseEntity
    {
        public string ImageUrl {get;set;}
        public bool IsActive { get;set;}    
        public int ProductId;
        public Product Product { get; set; }
    }
}
