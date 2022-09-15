namespace Resturants.API.Dtos
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int CustomerId1 { get; set; }
        public int ResturantId { get; set; }

    }
}
