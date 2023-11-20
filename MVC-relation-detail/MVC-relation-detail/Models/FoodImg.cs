namespace MVC_relation_detail.Models
{
    public class FoodImg
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
    }
}
