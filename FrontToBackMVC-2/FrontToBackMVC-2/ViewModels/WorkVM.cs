using FrontToBackMVC_2.Models;

namespace FrontToBackMVC_2.ViewModels
{
    public class WorkVM
    {
        public List<Work> Works { get; set; }
        public List<Catagory> Catagories { get; set; }
        public List<WorkImage> Images { get; set; }
    }
}
