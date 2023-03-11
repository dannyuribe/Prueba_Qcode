using Qcode.BusinessLogic.Interfaces;
using Qcode.Datos.repositorio.Generico;
using Qcode.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qcode.Datos.Constantes;

namespace Qcode.BusinessLogic.Servicios.TipoUsuarios
{
    public class TipoUsuarioServicio : ITipoUsuarioServicio
    {
        private readonly IRepositorioGenerico<TipoUsuario> _RepositorioTipoUsuario;
        public TipoUsuarioServicio(IRepositorioGenerico<TipoUsuario> repositorioGenerico)
        {
            _RepositorioTipoUsuario = repositorioGenerico;
        }
        public async Task AgregarTipoUsuario(TipoUsuario tipoUsuario)
        {
            if(tipoUsuario == null)
            {
                throw new Exception("No se encontro datos");
            }
            await _RepositorioTipoUsuario.Agregar(tipoUsuario);
        }

        public async Task EditarTipoUsuario(TipoUsuario tipoUsuario)
        {
            if (tipoUsuario == null)
            {
                throw new Exception("No se encontro datos");
            }
            await _RepositorioTipoUsuario.Actualizar(tipoUsuario);
        }

        public async Task<TipoUsuario> ObtenerTipoUsuarioPorId(int idTipoUsuario)
        {
            if (idTipoUsuario < 0)
            {
                throw new Exception("No se encontro datos");
            }
            return await _RepositorioTipoUsuario.ObtenerPorId(idTipoUsuario);
        }

        public async Task<List<TipoUsuario>> ObtenerTipoUsuariosPorPagina(int pagina)
        {
            if (pagina < 0)
            {
                throw new Exception("Numero pagina incorrecto");
            }
            var empleado = await _RepositorioTipoUsuario.ObtenerRegistros();

            return empleado
                    .Skip(Constantes.TamañoMaxioPorPagina * pagina)
                    .Take(Constantes.TamañoMaxioPorPagina)
                    .ToList();
        }
    }
}
