using APIHomework.DAL.Context;
using APIHomework.DAL.Entities;
using APIHomework.DAL.Repository;
using APIHomework.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerDocument();
builder.Services.AddDbContext<ProductContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbCon")));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();


builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<ProductContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("DbCon")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.UseOpenApi();
app.UseSwaggerUi3();

app.MapControllers();

app.Run();
