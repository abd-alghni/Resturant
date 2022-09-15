using AutoMapper;
using Resturants.API.Dtos;
using Resturants.API.Models;
using Resturants.API.ViewModels;

namespace Resturants.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();

            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();

            CreateMap<Resturant, ResturantViewModel>().ReverseMap();
            CreateMap<Resturant, CreateResturantDto>().ReverseMap();
            CreateMap<Resturant, UpdateResturantDto>().ReverseMap();

            CreateMap<Meal, MealViewModel>().ReverseMap();
            CreateMap<Meal, CreateMealDto>().ReverseMap();
            CreateMap<Meal, UpdateMealDto>().ReverseMap();
        }
    }
}
