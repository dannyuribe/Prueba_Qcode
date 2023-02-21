using AccesoDatos.Modelos;
using Datos.Contexto;
using Datos.repositorio.Generico;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.repositorio.Vehiculos
{
    public class VehiculoRepositorio : RepositorioGenerico<Vehiculo>
    {

        public VehiculoRepositorio(ReparacionesContext context):base(context) { }

        public async Task<Vehiculo> ObtenerVehiculo(string serialVehiculo)
        {
            using var contexto = new ReparacionesContext(new DbContextOptions<ReparacionesContext>());
                Vehiculo? vehiculo= await contexto.Vehiculos.Where(w => w.SerialVehiculo==serialVehiculo).FirstOrDefaultAsync();
            if (vehiculo!=null) { Console.WriteLine("null"); }
            return vehiculo;
        }
    }
}
