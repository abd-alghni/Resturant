using Resturants.API.Dtos;
using Resturants.API.ViewModels;

namespace Resturants.API.Services.Customers
{
    public interface ICustomerService
    {
        Task<List<CustomerViewModel>> GetAll();
        Task<CustomerViewModel> Get(int id);
        Task<int> Create(CreateCustomerDto dto);
        Task<int> Update(UpdateCustomerDto dto);
        Task<int> Delete(int id);
    }
}
