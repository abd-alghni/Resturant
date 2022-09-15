using Resturants.API.Dtos;
using Resturants.API.ViewModels;

namespace Resturants.API.Services.Meals
{
    public interface IMealService
    {
        Task<List<MealViewModel>> GetAll();
        Task<int> Update(UpdateMealDto dto);
        Task<int> Create(CreateMealDto dto);
        Task<int> Delete(int id);
        Task<MealViewModel> Get(int id);
    }
}
