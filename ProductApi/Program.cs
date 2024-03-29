using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Data.Repositories;
using ProductApi.Services;
using ProductApi.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add db
builder.Services
    .AddEntityFrameworkNpgsql()
    .AddDbContext<ApiDbContext>(
        opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("ProductDbConnection"))
    );

// Add repositories
builder.Services.AddTransient<IProductRepository, ProductRepository>();

// Add services
builder.Services.AddScoped<IProductsService, ProductsServiceImpl>();

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

app.UsePathBase(new PathString("/api"));

app.UseRouting();

app.Run();

public partial class Program { }
