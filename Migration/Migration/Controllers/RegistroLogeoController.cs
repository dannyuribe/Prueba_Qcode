using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qcode.BusinessLogic.Interfaces;
using Qcode.Datos.Modelos;

namespace Qcode.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class RegistroLogeoController : ControllerBase
    {
        private readonly IRegistroLogeoServicio _LogeoServicio;
        public RegistroLogeoController(IRegistroLogeoServicio logeoServicio)
        {
            _LogeoServicio = logeoServicio;
        }

        [HttpPost("registrar-logeo-usuario")]
        public async Task<IActionResult> RegistrarLogeoUsuario([FromBody]ActivarUsuarioLogeo registroLogeo) 
        {
            await _LogeoServicio.RegistrarUsuarioLogeo(registroLogeo);
            return Ok();
        }

        [HttpPost("activar-registro-logeo")]
        public async Task<IActionResult> ActivarUsuarioLogeo([FromForm] string codigoActivacion)
        {
            await _LogeoServicio.ActivarUsuarioLogeo(codigoActivacion);
            return Ok();
        }
    }
}
