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
        private readonly IVehiculoServicio _vehiculos;

        public VehiculosController(IVehiculoServicio vehiculoServicio)
        {
            _vehiculos = vehiculoServicio;
        }

        [HttpPost("Agregar-vehiculo")]
        public async Task AgregarVehiculo(Vehiculo vehiculo)
        {
            await _vehiculos.AgregarVehiculo(vehiculo);
        }

        [HttpGet("obtener-vehiculo-serial")]
        public async Task<Vehiculo> ObtenerPorSerialVehiculo(string serialVehiculo)
        {
            return await _vehiculos.ObtenerVehiculoPorSerial(serialVehiculo);
        }
    }
}
