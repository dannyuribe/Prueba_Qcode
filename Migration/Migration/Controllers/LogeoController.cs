using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qcode.BusinessLogic.Interfaces;
using Qcode.Datos.Modelos;

namespace Qcode.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class LogeoController : ControllerBase
    {
        private readonly ILogeoServicio _LogeoServicio;
        public LogeoController(ILogeoServicio logeoServicio)
        {
            _LogeoServicio = logeoServicio;
        }

        [HttpPost("registrar-logeo-usuario")]
        public async Task<IActionResult> RegistrarLogeoUsuario([FromBody]Logeos logeo) 
        {
            await _LogeoServicio.RegistrarUsuarioLogeo(logeo);
            return Ok();
        }
    }
}
