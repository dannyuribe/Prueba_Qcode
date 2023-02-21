using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Datos.repositorio.Generico
{
    public interface IRepositorioGenerico<T> where T : class
    {
        Task<IEnumerable<T>> ObtenerTodos();
        Task<T> ObtenerPorId(int id);
        Task Insertar(T entidad);
        Task Actualizar(T entidad);
        Task Eliminar(T entidad);
    }
}
