using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qcode.BusinessLogic.Interfaces;
using Qcode.Datos.Modelos;

namespace Qcode.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioServicio _TipoUsuarioServicio;

        public TipoUsuarioController(ITipoUsuarioServicio tipoUsuarioServicio)
        {
            _TipoUsuarioServicio = tipoUsuarioServicio;
        }

        [HttpPost("agregar-TipoUsuario")]
        public async Task<IActionResult> AgregarUsuario(TipoUsuario tipoUsuario)
        {
            await _TipoUsuarioServicio.AgregarTipoUsuario(tipoUsuario);
            return Ok();
        }

        [HttpPost("editar-TipoUsuario")]
        public async Task<IActionResult> EditarUsuario(TipoUsuario tipoUsuario)
        {
            await _TipoUsuarioServicio.EditarTipoUsuario(tipoUsuario);
            return Ok();
        }

        [HttpGet("obtener-TipoUsuarios-por-pagina")]
        public async Task<List<TipoUsuario>> ObtenerTipoUsuariosPorPagina(int pagina)
        {
            return await _TipoUsuarioServicio.ObtenerTipoUsuariosPorPagina(pagina);
        }

        [HttpGet("obtener-TipoUsuarios-por-id")]
        public async Task<TipoUsuario> ObtenerTipoUsuariosPorId(int idTipoUsuario)
        {
            return await _TipoUsuarioServicio.ObtenerTipoUsuarioPorId(idTipoUsuario);
        }
    }
}
