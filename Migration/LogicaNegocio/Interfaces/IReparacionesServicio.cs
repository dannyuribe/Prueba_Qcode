using Microsoft.AspNetCore.Http;
using Qcode.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.BusinessLogic.Interfaces
{
    public interface IReparacionesServicio
    {
        Task<int> AgregarReparaciones(Stream archivoExcel);
    }
}
