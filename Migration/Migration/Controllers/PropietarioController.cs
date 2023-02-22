using Microsoft.AspNetCore.Mvc;
using Qcode.BusinessLogic.Interfaces;
using Qcode.Datos.Modelos;


namespace Qcode.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PropietarioController : Controller
    {
        private readonly IPropietarioServicio _propietarioServicio;

        public PropietarioController(IPropietarioServicio propietarioServicio)
        {
            _propietarioServicio = propietarioServicio;
        }

        [HttpPost("Agregar-Propietario")]
        public async Task AgregarPropietario([FromBody]Propietario propietario)
        {
            await _propietarioServicio.AgregarPropietario(propietario);
        }

    }
}
