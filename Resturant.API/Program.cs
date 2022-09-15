using Microsoft.EntityFrameworkCore;
using Resturants.API.Models;
using Resturants.API;
using Resturants.API.Models;
using Resturants.API.Services.Categories;
using Resturants.API.Services.Customers;
using Resturants.API.Services.Meals;
using Resturants.API.Services.Order;
using Resturants.API.Services.Resturants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RestaurantDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);


builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddScoped<IResturantService, ResturantService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
