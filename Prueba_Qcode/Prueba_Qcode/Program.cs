using data.configuracion;

var builder = WebApplication.CreateBuilder(args);

//Reglas Cors
var ReglasCors = "CorsReparacionVehivulos";

builder.Services.AddCors(opc =>
{
    opc.AddPolicy(ReglasCors, builder =>
    {
        builder
        .AllowAnyOrigin()
        .WithOrigins("http://localhost:8080")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

//add services DataBase

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services
    .AddSingleton(
    new ConfiguraConeccion(
        builder.Configuration.GetConnectionString("MySqlConnection")));
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();
//
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseCors("CorsReparacionVehivulos");
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
