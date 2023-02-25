using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
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
        Task Agregar(T entity);
        Task Actualizar(T entity);
        Task<IDbContextTransaction> BeginTransaction();
        Task<T> ObtenerRegistroPorCondicion(Expression<Func<T, bool>> condicion);
        Task<List<T>> ObtenerRegistrosPorCondicion(Expression<Func<T, bool>> condicion);
    }
}
