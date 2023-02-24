using Qcode.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.BusinessLogic.Interfaces
{
    public interface IEstadosReparacionServicio
    {
        Task Agregar(EstadoReparacion estadoReparacion);
        Task Actualizar(EstadoReparacion estadoReparacion);
    }
}
