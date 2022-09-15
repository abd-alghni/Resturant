using Resturants.API.Dtos;
using Resturants.API.ViewModels;

namespace Resturants.API.Services.Order
{
    public interface IOrderService
    {
        Task<List<OrderViewModel>> GetAll();
        Task<int> Update(UpdateOrderDto dto);
        Task<int> Create(CreateOrderDto dto);
        Task<int> Delete(int id);
        Task<OrderViewModel> Get(int id);
    }
}
