using Microsoft.AspNetCore.Mvc;
using Qcode.BusinessLogic.Interfaces;
using Qcode.BusinessLogic.servicios.Vehiculos;
using Qcode.Datos.Modelos;

namespace Qcode.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class VehiculosController : Controller
    {
        private readonly IVehiculoServicio _vehiculosServicios;

        public VehiculosController(IVehiculoServicio vehiculoServicio)
        {
            _vehiculosServicios = vehiculoServicio;
        }

        [HttpPost("Agregar-vehiculo")]
        public async Task AgregarVehiculo(Vehiculo vehiculo)
        {
            await _vehiculosServicios.AgregarVehiculo(vehiculo);
        }

        [HttpGet("obtener-vehiculo")]
        public async Task<Vehiculo> ObtenerPorSerialVehiculo(string serialVehiculo)
        {
            return await _vehiculosServicios.ObtenerVehiculoPorSerial(serialVehiculo);
        }

        [HttpPost("Cargar-Reparaciones-Excel")]
        public async Task<IActionResult> CargarReparacionesExcel(IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
            {
                return BadRequest("No se ha cargado ningún archivo.");
            }

            using (var stream = new MemoryStream())
            {
                await archivo.CopyToAsync(stream);
                stream.Position = 0;

                await _vehiculosServicios.CargarVehiculos(stream);
            }
            return Ok();
        }
    }
}
