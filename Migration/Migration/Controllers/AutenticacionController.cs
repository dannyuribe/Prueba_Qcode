using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qcode.BusinessLogic.Interfaces;

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
        public IActionResult Autenticacion(string usuario,string contrasena)
        {
            var token = _jwtAutenticacionServicio.Autenticacion(usuario, contrasena);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token = token });
        }
    }
}
