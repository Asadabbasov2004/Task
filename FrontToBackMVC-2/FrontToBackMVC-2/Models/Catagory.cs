namespace FrontToBackMVC_2.Models
{
    public class Catagory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        List<Work > Works { get; set; }
    }
}
