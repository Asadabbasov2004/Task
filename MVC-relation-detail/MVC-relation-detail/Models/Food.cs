namespace MVC_relation_detail.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CatagoryId { get; set; }
        public Catagory Catagory { get; set;}
        public List<FoodImg> Images { get; set; }
        
        
    }
}
