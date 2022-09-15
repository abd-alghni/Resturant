using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturants.API.Dtos;
using Resturants.API.Services.Order;

namespace Resturants.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _orderService.GetAll();
            return Ok(orders);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderDto dto)
        {
            var order = _orderService.Create(dto);
            return Ok(order);
        }
        [HttpPut]
        public IActionResult Update(UpdateOrderDto dto)
        {
            var order = _orderService.Update(dto);
            return Ok(order);
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            var order = _orderService.Get(id);
            return Ok(order);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deleteId = _orderService.Delete(id);
            return Ok(deleteId);
        }
    }
}
