using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qcode.BusinessLogic.Interfaces;
using Qcode.Datos.Modelos;

namespace Qcode.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly IJwtAutenticacionServicio _jwtAutenticacionServicio;

        public AutenticacionController(IJwtAutenticacionServicio jwtAutenticacionServicio)
        {
           _jwtAutenticacionServicio = jwtAutenticacionServicio;
        }

        [HttpPost("Autenticar")]
        public IActionResult Autenticacion([FromBody]string logeo,string contrasena)
        {
            var token = _jwtAutenticacionServicio.Autenticacion(logeo,contrasena);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token = token });
        }

        [HttpPost("Validar-Token")]
        public async Task<IActionResult> ValidarToken(string token)
        {
            await _jwtAutenticacionServicio.ValidarToken(token);
            return Ok();
        }
    }


}
