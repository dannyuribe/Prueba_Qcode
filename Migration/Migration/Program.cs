using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Qcode.BusinessLogic.Interfaces;
using Qcode.BusinessLogic.servicios.Vehiculos;
using Qcode.BusinessLogic.Servicios.Autenticacion;
using Qcode.Datos.Contexto;
using Qcode.Datos.Modelos;
using Qcode.Datos.repositorio.Generico;
using System.Configuration;
using System.Text;

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
builder.Services.AddTransient(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));

builder.Services.AddTransient<IVehiculoServicio, VehiculoServicio>();

//Jwt
builder.Services.AddScoped<IJwtAutenticacionServicio, JwtAutenticacionServicio>();
builder.Services.AddScoped<IJwtTokenServicio, JwtTokenServicio>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
