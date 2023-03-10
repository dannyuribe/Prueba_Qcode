using Qcode.BusinessLogic.Interfaces;
using Qcode.Datos.Constantes;
using Qcode.Datos.Modelos;
using Qcode.Datos.repositorio.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.BusinessLogic.Servicios.Empleados
{
    public class EmpleadoServicio : IEmpleadoServicio
    {
        private readonly IRepositorioGenerico<Empleado> _RepositorioEmpleado;
        public EmpleadoServicio(IRepositorioGenerico<Empleado> repositorioEmpleado)
        {
            _RepositorioEmpleado = repositorioEmpleado;
        }
        public async Task AgregarEmpleado(Empleado empleado)
        {
            if(empleado == null)
            {
                throw new Exception("No se encontraron datos.");
            }

            await _RepositorioEmpleado.Agregar(empleado);
        }

        public async Task EditarEmpleado(Empleado empleado)
        {
            if (empleado == null)
            {
                throw new Exception("No se encontraron datos.");
            }

            await _RepositorioEmpleado.Actualizar(empleado);
        }

        public async Task<Empleado> ObtenerEmpleado(string idEmpleado)
        {
            if (string.IsNullOrEmpty(idEmpleado))
            {
                throw new Exception("Debes ingresar el id del Empleado.");
            }
            return await _RepositorioEmpleado.ObtenerPorId(idEmpleado);
        }

        public async Task<List<Empleado>> ObtenerEmpleadosPorPagina(int pagina)
        {
            if(pagina < 0)
            {
                throw new Exception("Numero pagina incorrecto");
            }
            var empleado = await _RepositorioEmpleado.ObtenerRegistros();

            return empleado
                    .Skip(Constantes.TamañoMaxioPorPagina * pagina)
                    .Take(Constantes.TamañoMaxioPorPagina)
                    .ToList();

        }
    }
}
