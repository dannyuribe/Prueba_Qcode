using AccesoDatos.Modelos;
using LogicaNegocio.servicios.Vehiculos;
using Microsoft.AspNetCore.Mvc;

namespace Migration.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class VehiculosController : Controller
    {
        private readonly VehiculoServicio _vehiculos;

        public VehiculosController()
        {
            _vehiculos = new VehiculoServicio();
        }

        [HttpGet("obtener-vehiculo-serial")]
        public Task<Vehiculo> ObtenerPorSerialVehiculo(string serialVehiculo)
        {
            return _vehiculos.ObtenerPorSerialVehiculo(serialVehiculo);
        }
    }
}
