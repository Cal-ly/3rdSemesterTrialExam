global using Microsoft.AspNetCore.Builder;
global using WoodPelletsLib;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<WoodPelletRepository>(provider =>
{
    var repository = new WoodPelletRepository();
    AddMockData(repository);
    return repository;
});

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();

app.Run();

static void AddMockData(WoodPelletRepository repository)
{
    repository.Add(new WoodPellet { Brand = "BrandA", Price = 99.95m, Quantity = 3 });
    repository.Add(new WoodPellet { Brand = "BrandB", Price = 129.95m, Quantity = 2 });
    repository.Add(new WoodPellet { Brand = "BrandC", Price = 99.95m, Quantity = 4 });
    repository.Add(new WoodPellet { Brand = "BrandD", Price = 119.95m, Quantity = 1 });
    repository.Add(new WoodPellet { Brand = "BrandE", Price = 139.95m, Quantity = 5 });
}
