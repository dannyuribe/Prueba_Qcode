using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qcode.BusinessLogic.Interfaces;
using Qcode.Datos.Modelos;
using System.Linq;

namespace Qcode.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class VehiculosController : Controller
    {
        private readonly IVehiculoServicio _vehiculosServicios;

        public VehiculosController(IVehiculoServicio vehiculoServicio)
        {
            _vehiculosServicios = vehiculoServicio;
        }

        [Authorize]
        [HttpPost("cargar-vehiculo")]
        public async Task<IActionResult> AgregarVehiculo(IFormFile archivo, [FromForm] Vehiculo vehiculo)
        {
            if (archivo == null || archivo.Length == 0)
            {
                return BadRequest("No se ha cargado ningún archivo.");
            }
            var fileName = Path.GetFileName(archivo.FileName);
            var filePath = Path.Combine("C:\\imagenes", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await archivo.CopyToAsync(stream);
                vehiculo.rutaImagen = filePath;
                await _vehiculosServicios.AgregarVehiculo(vehiculo);
            }            
            return Ok();
        }
        //[Authorize]
        [HttpPost("cargar-excel-vehiculos")]
        public async Task<IActionResult> CargarReparacionesExcel(IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
            {
                return BadRequest("No se ha cargado ningún archivo.");
            }
            var allowedExtensions = new[] { ".xlsx", ".xls" };
            var extension = Path.GetExtension(archivo.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(extension))
            {
                return BadRequest("El archivo no es una hoja de cálculo de Excel");
            }
            using var stream = new MemoryStream();            
            await archivo.CopyToAsync(stream);
            stream.Position = 0;
            await _vehiculosServicios.CargarVehiculos(stream);            
            return Ok();
        }
        [Authorize]
        [HttpPost("editar-vehiculo")]
        public async Task<IActionResult> EditarVehiculo(IFormFile archivo, [FromForm] Vehiculo vehiculo)
        {
            if (archivo == null || archivo.Length == 0)
            {
                return BadRequest("No se ha cargado ningún archivo.");
            }
            var fileName = Path.GetFileName(archivo.FileName);
            // se simula una ruta para el almacenamiento de la imagen en el disco local C
            var filePath = Path.Combine("C:\\imagenes", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await archivo.CopyToAsync(stream);
                vehiculo.rutaImagen = filePath;
                await _vehiculosServicios.EditarVehiculo(vehiculo);
            }

            return Ok();
        }
        [Authorize]
        [HttpGet("obtener-vehiculo")]
        public async Task<Vehiculo> ObtenerPorSerialVehiculo(string serialVehiculo)
        {
            return await _vehiculosServicios.ObtenerVehiculoPorSerial(serialVehiculo);
        }

        [Authorize]
        [HttpGet("obtener-vehiculos")]
        public async Task<List<Vehiculo>> ObtenerVehiculos()
        {
            return await _vehiculosServicios.ObtenerVehiculos();
        }

    }
}
