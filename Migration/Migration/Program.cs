using Microsoft.EntityFrameworkCore;
using Qcode.BusinessLogic.Interfaces;
using Qcode.BusinessLogic.servicios.Vehiculos;
using Qcode.Datos.Contexto;
using Qcode.Datos.Modelos;
using Qcode.Datos.repositorio.Generico;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// DbConnection

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
var cadenaConexion = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContext<ReparacionesContext>(options => options.UseMySQL(cadenaConexion));

//builder.Services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));


//builder.Services.AddSingleton<IRepositorioGenerico<Vehiculo>, RepositorioGenerico<Vehiculo>>();
builder.Services.AddSingleton<IVehiculoServicio,VehiculoServicio>();
builder.Services.AddControllersWithViews();

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
