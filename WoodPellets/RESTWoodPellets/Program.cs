global using Microsoft.AspNetCore.Builder;
global using WoodPelletsLib;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<WoodPelletRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
