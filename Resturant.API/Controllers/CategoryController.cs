using Microsoft.AspNetCore.Mvc;
using Resturants.API.Dtos;
using Resturants.API.Services.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resturants.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateCategoryDto dto)
        {
            var category = _categoryService.Create(dto);
            return Ok(category);
        }
        [HttpPut]
        public IActionResult Update(UpdateCategoryDto dto)
        {
            var category = _categoryService.Update(dto);
            return Ok(category);
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            var category = _categoryService.Get(id);
            return Ok(category);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deleteId = _categoryService.Delete(id);
            return Ok(deleteId);
        }
        [HttpGet]
        private IActionResult IsAvailableMealsInThisCategory(int id)
        {
            var category = _categoryService.isAvailableMealsInThisCategory(id);
            return Ok(category);

        }

    }
}
