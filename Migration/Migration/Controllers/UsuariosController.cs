using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qcode.BusinessLogic.Interfaces;
using Qcode.Datos.Modelos;

namespace Qcode.Api.Controllers
{ 
    [Route("/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioServicio _UsuariosServicio;
        public UsuariosController(IUsuarioServicio empleadoServicio)
        {
            _UsuariosServicio= empleadoServicio;
        }

        [HttpPost ("agregar-Usuario")]
        public  async Task<IActionResult> AgregarUsuario(Usuario empleado) 
        {
            await _UsuariosServicio.AgregarUsuario(empleado);
            return Ok();
        }
        [HttpPost("editar-Usuario")]
        public async Task<IActionResult> EditarUsuario(Usuario empleado)
        {
            await _UsuariosServicio.EditarUsuario(empleado);
            return Ok();
        }
        [HttpGet("obtener-Usuarios-por-pagina")]
        public async Task<List<Usuario>> ObtenerUsuariosPorPagina(int pagina)
        {
            return await _UsuariosServicio.ObtenerUsuariosPorPagina(pagina);
        }
        [HttpGet("obtener-Usuario-por-id")]
        public async Task<Usuario> ObertenerUsuarioPorId(string idEmpleado)
        {
            return await _UsuariosServicio.ObtenerUsuarioPorId(idEmpleado);
        }
    }
}
