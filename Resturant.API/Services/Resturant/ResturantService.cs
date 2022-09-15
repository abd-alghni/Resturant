using AutoMapper;
using Resturants.API.Models;
using Resturants.API.Dtos;
using Resturants.API.ViewModels;

namespace Resturants.API.Services.Resturants
{
    public class ResturantService : IResturantService
    {
        private readonly RestaurantDbContext _db;
        private readonly IMapper _mapper;
        public ResturantService(RestaurantDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<List<ResturantViewModel>> GetAll()
        {
            var resturants = _db.Resturants.ToList();

            return _mapper.Map<List<ResturantViewModel>>(resturants);
        }
        public async Task<int> Update(UpdateResturantDto dto)
        {
            var resturant = await _db.Resturants.FindAsync(dto.Id);
            var updatedResturant = _mapper.Map<UpdateResturantDto, Resturant>(dto, resturant);
            _db.Resturants.Update(updatedResturant);
            _db.SaveChangesAsync();
            return resturant.Id;
        }
        public async Task<int> Create(CreateResturantDto dto)
        {
            var resturant = _mapper.Map<Resturant>(dto);
            _db.Resturants.Add(resturant);
            _db.SaveChanges();
            return resturant.Id;
        }
        public async Task<int> Delete(int id)
        {
            var resturant = _db.Resturants.SingleOrDefault(x => x.Id == id);
            resturant.IsDelete = true;
            _db.Resturants.Update(resturant);
            _db.SaveChanges();
            return resturant.Id;
        }
        public async Task<ResturantViewModel> Get(int id)
        {
            var resturant = _db.Resturants.SingleOrDefault(x => x.Id == id);
            var resturantVm = _mapper.Map<ResturantViewModel>(resturant);
            return resturantVm;
        }
    }
}
