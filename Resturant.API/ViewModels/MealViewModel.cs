namespace Resturants.API.ViewModels
{
    public class MealViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float PriceInUsd { get; set; }
        public float PriceInNis { get; set; }
        public int CategoryId { get; set; }
        public int ResturantId { get; set; }
    }
}
