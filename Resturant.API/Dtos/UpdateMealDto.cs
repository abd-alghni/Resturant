namespace Resturants.API.Dtos
{
    public class UpdateMealDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float PriceInUsd { get; set; }
        public int CategoryId { get; set; }
        public int ResturantId { get; set; }
    }
}
