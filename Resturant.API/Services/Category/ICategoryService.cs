using Resturants.API.Dtos;
using Resturants.API.ViewModels;

namespace Resturants.API.Services.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAll();
        Task<CategoryViewModel> Get(int id);
        Task<int> Create(CreateCategoryDto dto);
        Task<int> Update(UpdateCategoryDto dto);
        Task<int> Delete(int id);
        bool isAvailableMealsInThisCategory(int id);
    }
}
