using Qcode.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.BusinessLogic.Interfaces
{
    public interface IEmpleadoServicio
    {
        Task AgregarEmpleado(Empleado empleado);
        Task EditarEmpleado(Empleado empleado);
        Task<List<Empleado>> ObtenerEmpleadosPorPagina(int pagina);
        Task<Empleado> ObtenerEmpleado(string idempleado);
    }
}
