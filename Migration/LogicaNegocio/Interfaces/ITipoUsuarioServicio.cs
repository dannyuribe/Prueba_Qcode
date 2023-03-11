using Qcode.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.BusinessLogic.Interfaces
{
    public interface ITipoUsuarioServicio
    {
        Task AgregarTipoUsuario(TipoUsuario tipoUsuario);
        Task EditarTipoUsuario(TipoUsuario tipoUsuario);
        Task<TipoUsuario> ObtenerTipoUsuarioPorId(int idTipoUsuario);
        Task<List<TipoUsuario>> ObtenerTipoUsuariosPorPagina(int pagina);
    }
}
