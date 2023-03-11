using Qcode.BusinessLogic.Interfaces;
using Qcode.Datos.Constantes;
using Qcode.Datos.Modelos;
using Qcode.Datos.repositorio.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.BusinessLogic.Servicios.Usuarios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IRepositorioGenerico<Usuario> _RepositorioUsuario;
        public UsuarioServicio(IRepositorioGenerico<Usuario> repositorioEmpleado)
        {
            _RepositorioUsuario = repositorioEmpleado;
        }
        public async Task AgregarUsuario(Usuario empleado)
        {
            if(empleado == null)
            {
                throw new Exception("No se encontraron datos.");
            }

            await _RepositorioUsuario.Agregar(empleado);
        }

        public async Task EditarUsuario(Usuario empleado)
        {
            if (empleado == null)
            {
                throw new Exception("No se encontraron datos.");
            }

            await _RepositorioUsuario.Actualizar(empleado);
        }

        public async Task<Usuario> ObtenerUsuarioPorId(string idEmpleado)
        {
            if (string.IsNullOrEmpty(idEmpleado))
            {
                throw new Exception("Debes ingresar el id del Empleado.");
            }
            return await _RepositorioUsuario.ObtenerPorId(idEmpleado);
        }

        public async Task<List<Usuario>> ObtenerUsuariosPorPagina(int pagina)
        {
            if(pagina < 0)
            {
                throw new Exception("Numero pagina incorrecto");
            }
            var empleado = await _RepositorioUsuario.ObtenerRegistros();

            return empleado
                    .Skip(Constantes.TamañoMaxioPorPagina * pagina)
                    .Take(Constantes.TamañoMaxioPorPagina)
                    .ToList();

        }
    }
}
