using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturants.API.Dtos;
using Resturants.API.Services.Customers;

namespace Resturants.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _customerService.GetAll();
            return Ok(customers);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateCustomerDto dto)
        {
            var customer = _customerService.Create(dto);
            return Ok(customer);
        }
        [HttpPut]
        public IActionResult Update(UpdateCustomerDto dto)
        {
            var customer = _customerService.Update(dto);
            return Ok(customer);
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            var customer = _customerService.Get(id);
            return Ok(customer);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deleteId = _customerService.Delete(id);
            return Ok(deleteId);
        }
    }
}
