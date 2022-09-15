using AutoMapper;
using Newtonsoft.Json;
using Resturants.API.Models;
using Resturants.API.Dtos;
using Resturants.API.Models;
using Resturants.API.ViewModels;

namespace Resturants.API.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly RestaurantDbContext _db;
        private readonly IMapper _mapper;
        public CategoryService(RestaurantDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<List<CategoryViewModel>> GetAll()
        {
            var categories = _db.Categories.ToList();

            return _mapper.Map<List<CategoryViewModel>>(categories);
        }
        public async Task<int> Update(UpdateCategoryDto dto)
        {
            var category = await _db.Categories.FindAsync(dto.Id);
            var updatedCategory = _mapper.Map<UpdateCategoryDto, Category>(dto, category);
            _db.Categories.Update(updatedCategory);
            _db.SaveChangesAsync();
            return category.Id;
        }
        public async Task<int> Create(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            _db.Categories.Add(category);
            _db.SaveChanges();
            return category.Id;
        }
        public async Task<int> Delete(int id)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == id);
            if (category == null)
            {
                //throw
            }
            category.IsDelete = true;
            _db.Categories.Update(category);
            _db.SaveChanges();
            return category.Id;
        }
        public async Task<CategoryViewModel> Get(int id)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == id);
            if (category == null)
            {
                //throw
            }
            var categoryVm = _mapper.Map<CategoryViewModel>(category);
            categoryVm.MealCount = _db.Meals.Count(x => x.CategoryId == x.Id);
            return categoryVm;
        }
        public bool isAvailableMealsInThisCategory(int id)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == id);
            if (category == null)
            {
                return false;
            }
            else
            {
                var categoryVm = _mapper.Map<CategoryViewModel>(category);
                categoryVm.MealCount = _db.Meals.Count(x => x.CategoryId == x.Id);

                return true;
            }
            
        }
    }
}
