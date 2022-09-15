using AutoMapper;
using Resturants.API.Models;
using Resturants.API.Dtos;
using Resturants.API.Models;
using Resturants.API.ViewModels;

namespace Resturants.API.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly RestaurantDbContext _db;
        private readonly IMapper _mapper;
        public CustomerService(RestaurantDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<List<CustomerViewModel>> GetAll()
        {
            var customers = _db.Customers.ToList();

            return _mapper.Map<List<CustomerViewModel>>(customers);
        }
        public async Task<int> Update(UpdateCustomerDto dto)
        {
            var customer = await _db.Customers.FindAsync(dto.Id);
            var updatedCustomer = _mapper.Map<UpdateCustomerDto, Customer>(dto, customer);
            _db.Customers.Update(updatedCustomer);
            _db.SaveChangesAsync();
            return customer.Id;
        }
        public async Task<int> Create(CreateCustomerDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);
            _db.Customers.Add(customer);
            _db.SaveChanges();
            return customer.Id;
        }
        public async Task<int> Delete(int id)
        {
            var customer = _db.Customers.SingleOrDefault(x => x.Id == id);
            customer.IsDelete = true;
            _db.Customers.Update(customer);
            _db.SaveChanges();
            return customer.Id;
        }
        public async Task<CustomerViewModel> Get(int id)
        {
            var customer = _db.Customers.SingleOrDefault(x => x.Id == id);
            var customerVm = _mapper.Map<CustomerViewModel>(customer);
            return customerVm;
        }
    }
}
