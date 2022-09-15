namespace Resturants.API.Dtos
{
    public class CreateOrderDto
    {
        public int Quantity { get; set; }
        public int CustomerId1 { get; set; }
        public int ResturantId { get; set; }
    }
}
