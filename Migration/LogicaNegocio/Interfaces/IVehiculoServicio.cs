using Qcode.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.BusinessLogic.Interfaces
{
    public interface IVehiculoServicio
    {
        Task AgregarVehiculo(Vehiculo vehiculo);
        Task CargarVehiculos(Stream archivoExcel);
        Task EditarVehiculo(Vehiculo vehiculo);
        Task<Vehiculo> ObtenerVehiculoPorSerial(String id);
        
    }
}
