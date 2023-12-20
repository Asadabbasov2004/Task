using First_Api.Entities;

namespace First_Api.DTOs.BrandDTOs
{
    public class CreateBrandDto
    {
        public string Name { get; set; }
        public List<Car>? Cars { get; set; }
    }
}
