using Datos.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.repositorio.Generico
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        private readonly DbContext _context;
        public RepositorioGenerico(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> ObtenerTodos()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> ObtenerPorId(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Insertar(T entidad)
        {
            await _context.Set<T>().AddAsync(entidad);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(T entidad)
        {
            _context.Entry(entidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(T entidad)
        {
            _context.Set<T>().Remove(entidad);
            await _context.SaveChangesAsync();
        }
    }
}
