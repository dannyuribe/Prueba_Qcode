using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Qcode.BusinessLogic.Interfaces;
using Qcode.BusinessLogic.servicios.Vehiculos;
using Qcode.BusinessLogic.Servicios.Autenticacion;
using Qcode.BusinessLogic.Servicios.TipoUsuarios;
using Qcode.BusinessLogic.Servicios.Usuarios;
using Qcode.Datos.Contexto;
using Qcode.Datos.repositorio.Generico;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



//Reglas Cors
var ReglasCors = "CorsP";
builder.Services.AddCors(options =>
{
    options.AddPolicy(ReglasCors, builder =>
    {
        builder
        .AllowAnyOrigin()
        .WithOrigins("http://localhost:8081")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// autenticacion esquema 


// DbConnection

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
var cadenaConexion = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContext<ReparacionesContext>(options => options.UseMySQL(cadenaConexion));

builder.Services.AddTransient(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));
builder.Services.AddTransient<IVehiculoServicio, VehiculoServicio>();
builder.Services.AddTransient<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddTransient<ITipoUsuarioServicio, TipoUsuarioServicio>();

//Jwt
builder.Services.AddScoped<IJwtAutenticacionServicio, JwtAutenticacionServicio>();
builder.Services.AddScoped<IJwtTokenServicio, JwtTokenServicio>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsP");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
