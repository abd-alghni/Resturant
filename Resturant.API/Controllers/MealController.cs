using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturants.API.Dtos;
using Resturants.API.Services.Meals;

namespace Resturants.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MealController : ControllerBase
    {
        private readonly IMealService _mealService;

        public MealController(IMealService mealService)
        {
            _mealService = mealService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var meals = _mealService.GetAll();
            return Ok(meals);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateMealDto dto)
        {
            var meal = _mealService.Create(dto);
            return Ok(meal);
        }
        [HttpPut]
        public IActionResult Update(UpdateMealDto dto)
        {
            var meal = _mealService.Update(dto);
            return Ok(meal);
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            var meal = _mealService.Get(id);
            return Ok(meal);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deleteId = _mealService.Delete(id);
            return Ok(deleteId);
        }
    }
}
