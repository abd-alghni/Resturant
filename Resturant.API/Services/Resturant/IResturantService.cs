using Resturants.API.Dtos;
using Resturants.API.ViewModels;

namespace Resturants.API.Services.Resturants
{
    public interface IResturantService
    {
        Task<List<ResturantViewModel>> GetAll();
        Task<int> Update(UpdateResturantDto dto);
        Task<int> Create(CreateResturantDto dto);
        Task<int> Delete(int id);
        Task<ResturantViewModel> Get(int id);
    }
}
