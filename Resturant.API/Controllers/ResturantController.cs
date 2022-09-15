using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturants.API.Dtos;
using Resturants.API.Services.Resturants;

namespace Resturants.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ResturantController : ControllerBase
    {
        private readonly IResturantService _resturantService;

        public ResturantController(IResturantService resturantService)
        {
            _resturantService = resturantService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var resturants = _resturantService.GetAll();
            return Ok(resturants);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateResturantDto dto)
        {
            var resturant = _resturantService.Create(dto);
            return Ok(resturant);
        }
        [HttpPut]
        public IActionResult Update(UpdateResturantDto dto)
        {
            var resturant = _resturantService.Update(dto);
            return Ok(resturant);
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            var resturant = _resturantService.Get(id);
            return Ok(resturant);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deleteId = _resturantService.Delete(id);
            return Ok(deleteId);
        }
    }
}
