using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qcode.BusinessLogic.Interfaces;
using Qcode.Datos.Modelos;

namespace Qcode.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoServicio _EmpleadoServicio;
        public EmpleadosController(IEmpleadoServicio empleadoServicio)
        {
            _EmpleadoServicio= empleadoServicio;
        }

        [HttpPost ("agregar-Empleado")]
        public  async Task<IActionResult> AgregarEmpleado(Empleado empleado) 
        {
            await _EmpleadoServicio.AgregarEmpleado (empleado);
            return Ok();
        }
        [HttpPost("editar-Empleado")]
        public async Task<IActionResult> EditarEmpleado(Empleado empleado)
        {
            await _EmpleadoServicio.EditarEmpleado(empleado);
            return Ok();
        }
        [HttpGet("obtener-Empleados-por-pagina")]
        public async Task<List<Empleado>> ObtenerEmpleadosPorPagina(int pagina)
        {
            return await _EmpleadoServicio.ObtenerEmpleadosPorPagina(pagina);
        }
        [HttpGet("obtener-Empleados-por-id")]
        public async Task<Empleado> ObertenerEmpleadoPorId(string idEmpleado)
        {
            return await _EmpleadoServicio.ObtenerEmpleado(idEmpleado);
        }
    }
}
