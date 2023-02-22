using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.Datos.repositorio.Generico
{
    public interface IRepositorioGenerico<T> where T : class
    {
        IEnumerable<T> ObtenerTodos();
        Task<T> ObtenerPorId(String id);
        Task<T> ObtenerPorId(int id);
        Task<IEnumerable<T>> ObtenerPorCondicion(Expression<Func<T, bool>> condicion);
        Task Agregar(T entity);
        Task Actualizar(T entity);
        Task Eliminar(int id);

    }
}
