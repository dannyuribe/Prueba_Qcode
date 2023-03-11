using Qcode.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.BusinessLogic.Interfaces
{
    public interface IUsuarioServicio
    {
        Task AgregarUsuario(Usuario usuario);
        Task EditarUsuario(Usuario usuario);
        Task<List<Usuario>> ObtenerUsuariosPorPagina(int pagina);
        Task<Usuario> ObtenerUsuarioPorId(string idUsuario);
    }
}
