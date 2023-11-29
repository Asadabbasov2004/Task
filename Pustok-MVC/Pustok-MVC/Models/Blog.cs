namespace Pustok_MVC.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        //relation for BlogImgs ,many to many
        public List<BlogImgs> blogImgs { get; set; }

        //relation for tag ,many to many
        public List<BlogTag>? blogTags { get; set; }

        //relation to category ,one to many
        public int CatagoryId  { get; set;}
        public Catagory Catagory { get; set; }

    }
}
