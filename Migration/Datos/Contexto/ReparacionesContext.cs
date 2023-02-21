using AccesoDatos.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace Datos.Contexto
{
    public class ReparacionesContext: DbContext
    {
        private readonly string dbConnectionString;

        public ReparacionesContext(string cadenaConexion)
        {
            dbConnectionString = cadenaConexion;
        }

        public ReparacionesContext(DbContextOptions<ReparacionesContext> options):base(options) { }

        public virtual DbSet<Diagnostico> Diagnosticos { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<EstadoReparacion> EstadoReparacion { get; set; }
        public virtual DbSet<Reparacion> Reparaciones { get; set; }
        public virtual DbSet<Propietario> Propietarios { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySQL(dbConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder) 
        {
        }

    }
}
