using AutoMapper;
using Resturants.API.Models;
using Resturants.API.Dtos;
using Resturants.API.Models;
using Resturants.API.ViewModels;

namespace Resturants.API.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly RestaurantDbContext _db;
        private readonly IMapper _mapper;
        public OrderService(RestaurantDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<List<OrderViewModel>> GetAll()
        {
            var orders = _db.Orders.ToList();

            return _mapper.Map<List<OrderViewModel>>(orders);
        }
        public async Task<int> Update(UpdateOrderDto dto)
        {
            var order = await _db.Orders.FindAsync(dto.Id);
            var updatedOrder = _mapper.Map<UpdateOrderDto, Models.Order>(dto, order);
            _db.Orders.Update(updatedOrder);
            _db.SaveChangesAsync();
            return order.Id;
        }
        public async Task<int> Create(CreateOrderDto dto)
        {
            var order = _mapper.Map<Models.Order>(dto);
            _db.Orders.Add(order);
            _db.SaveChanges();
            return order.Id;
        }
        public async Task<int> Delete(int id)
        {
            var order = _db.Orders.SingleOrDefault(x => x.Id == id);
            order.IsDelete = true;
            _db.Orders.Update(order);
            _db.SaveChanges();
            return order.Id;
        }
        public async Task<OrderViewModel> Get(int id)
        {
            var order = _db.Meals.SingleOrDefault(x => x.Id == id);
            var orderVm = _mapper.Map<OrderViewModel>(order);
            return orderVm;
        }
    }
}
