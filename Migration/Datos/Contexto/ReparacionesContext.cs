

using Qcode.Datos.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace Qcode.Datos.Contexto
{
    public class ReparacionesContext: DbContext
    {

        public ReparacionesContext(DbContextOptions<ReparacionesContext> options) : base(options) { }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }
    }
}
