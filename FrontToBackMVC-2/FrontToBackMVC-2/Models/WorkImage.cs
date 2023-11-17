namespace FrontToBackMVC_2.Models
{
    public class WorkImage
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int WorkId { get; set; } 
        Work Work { get; set; }
    }
}
