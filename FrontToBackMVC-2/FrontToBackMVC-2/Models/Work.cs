namespace FrontToBackMVC_2.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int CatogoryId { get; set; }
        Catagory Catagory { get; set; }
        List<WorkImage> Images { get; set; }


        public DateTime CreatedDate { get; set; }
    }
}
