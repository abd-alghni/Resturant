using AutoMapper;
using Resturants.API.Models;
using Resturants.API.Dtos;
using Resturants.API.ViewModels;

namespace Resturants.API.Services.Meals
{
    public class MealService : IMealService
    {
        private readonly RestaurantDbContext _db;
        private readonly IMapper _mapper;
        public MealService(RestaurantDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<List<MealViewModel>> GetAll()
        {
            var meals = _db.Meals.ToList();

            return _mapper.Map<List<MealViewModel>>(meals);
        }
        public async Task<int> Update(UpdateMealDto dto)
        {
            var meal = await _db.Meals.FindAsync(dto.Id);
            var updatedMeal = _mapper.Map<UpdateMealDto, Meal>(dto, meal);
            _db.Meals.Update(updatedMeal);
            _db.SaveChangesAsync();
            return meal.Id;
        }
        public async Task<int> Create(CreateMealDto dto)
        {
            var meal = _mapper.Map<Meal>(dto);
            meal.PriceInNis = dto.PriceInUsd * 3.50f;
            _db.Meals.Add(meal);
            _db.SaveChanges();
            return meal.Id;
        }
        public async Task<int> Delete(int id)
        {
            var meal = _db.Meals.SingleOrDefault(x => x.Id == id);
            meal.IsDelete = true;
            _db.Meals.Update(meal);
            _db.SaveChanges();
            return meal.Id;
        }
        public async Task<MealViewModel> Get(int id)
        {
            var meal = _db.Meals.SingleOrDefault(x => x.Id == id);
            var mealVm = _mapper.Map<MealViewModel>(meal);
            return mealVm;
        }
        
    }
}
