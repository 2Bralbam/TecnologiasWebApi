using Microsoft.EntityFrameworkCore;
using TecnologiasWebApi.Models.Entities;
using TecnologiasWebApi.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ChismografoContext>(
    optionsBuilder => optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=chismografo", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql")
    ));
builder.Services.AddTransient<ChismesRepositorio>();
builder.Services.AddTransient<UsuariosRepositorio>();
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
