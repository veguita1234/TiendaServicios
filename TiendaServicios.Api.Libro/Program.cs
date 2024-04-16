using FluentAssertions.Common;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Application;
using TiendaServicios.Api.Libro.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<New>());

builder.Services.AddDbContext<ContextLibrary>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDatabase")));

builder.Services.AddMediatR(typeof(New.Handler).Assembly);
builder.Services.AddAutoMapper(typeof(Queries.Execute));
                
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
