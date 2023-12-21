using Second_Api.Entities.Base;

namespace Second_Api.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TagName { get; set; }
    }
}
