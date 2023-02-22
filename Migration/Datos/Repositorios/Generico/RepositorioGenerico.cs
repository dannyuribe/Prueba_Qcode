using Microsoft.EntityFrameworkCore;
using Qcode.Datos.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.Datos.repositorio.Generico
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        protected readonly ReparacionesContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public RepositorioGenerico(ReparacionesContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public IEnumerable<T> ObtenerTodos()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<T> ObtenerPorId(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<T> ObtenerPorId(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Agregar(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Actualizar(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> ObtenerPorCondicion(Expression<Func<T, bool>> condicion)
        {
            return await _dbSet.Where(condicion).ToListAsync();
        }
    }
}
