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
        Task<Vehiculo> ObtenerVehiculoPorSerial(String id);
    }
}
