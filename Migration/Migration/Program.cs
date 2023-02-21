
using Datos.Contexto;
using Datos.repositorio.Generico;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// DbConnection

var cadenaConexion = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContext<ReparacionesContext>(options => options.UseMySQL(cadenaConexion));
builder.Services.AddScoped(typeof(RepositorioGenerico<>));
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
