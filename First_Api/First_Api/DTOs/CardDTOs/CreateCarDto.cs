namespace First_Api.DTOs.CardDTOs
{
    public class CreateCarDto
    {
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
