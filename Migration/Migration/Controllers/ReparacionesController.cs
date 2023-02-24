using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qcode.BusinessLogic.Interfaces;
using Qcode.BusinessLogic.Servicios.Reparaciones;
using Qcode.Datos.Modelos;

namespace Qcode.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReparacionesController : ControllerBase
    {
        private readonly IReparacionesServicio _reparacionesServicio;

        public ReparacionesController(IReparacionesServicio reparacionesServicio)
        {
            _reparacionesServicio = reparacionesServicio;
        }

        [HttpPost("Cargar-Reparaciones-Excel")]
        public async Task<IActionResult> CargarReparacionesExcel (IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
            {
                return BadRequest("No se ha cargado ningún archivo.");
            }

            using (var stream = new MemoryStream())
            {
                await archivo.CopyToAsync(stream);
                stream.Position = 0;

                await _reparacionesServicio.AgregarReparaciones(stream);
            }
            return Ok();
        }
    }
}
