using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qcode.BusinessLogic.Interfaces;
using Qcode.Datos.Modelos;

namespace Qcode.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class EstadoReparacionController : ControllerBase
    {
        private readonly IEstadosReparacionServicio _estadosReparacionServicio;

        public EstadoReparacionController(IEstadosReparacionServicio estadosReparacionServicio)
        {
            _estadosReparacionServicio = estadosReparacionServicio; 
        }

        [HttpGet("Agregar-EstadoReparacion")]
        public async Task AgregarEstadoReparacion(EstadoReparacion estadoReparacion) 
        {
            await _estadosReparacionServicio.Agregar(estadoReparacion);
        }
    }
}
