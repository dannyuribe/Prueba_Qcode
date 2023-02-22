using Microsoft.AspNetCore.Mvc;
using Qcode.BusinessLogic.servicios.Vehiculos;
using Qcode.Datos.Modelos;

namespace Qcode.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class VehiculosController : Controller
    {
        private readonly VehiculoServicio _vehiculos;

        public VehiculosController(VehiculoServicio vehiculoServicio)
        {
            _vehiculos = vehiculoServicio;
        }

        [HttpGet("obtener-vehiculo-serial")]
        public async Task<Vehiculo> ObtenerPorSerialVehiculo(string serialVehiculo)
        {
            return await _vehiculos.ObtenerVehiculoPorSerial(serialVehiculo);
        }
    }
}
