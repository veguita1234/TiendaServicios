using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.CarritoCompra.Application;
using TiendaServicios.Api.CarritoCompra.Persistence;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;
using TiendaServicios.Api.CarritoCompra.RemoteService;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IBooksService, BooksService>();

builder.Services.AddControllers();

builder.Services.AddDbContext<ContextCar>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("ConnectionDatabase"));
});

builder.Services.AddMediatR(typeof(New.Handler).Assembly);

builder.Services.AddHttpClient("Books", async config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Books"]);
}); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
