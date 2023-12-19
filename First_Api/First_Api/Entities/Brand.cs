namespace First_Api.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Car>? Cars { get; set; }

    }
}
