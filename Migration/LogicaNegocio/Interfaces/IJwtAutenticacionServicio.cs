using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.BusinessLogic.Interfaces
{
    public interface IJwtAutenticacionServicio
    {
        Task<string> Autenticacion(string usuario, string contrasena);
        Task ValidarToken(string token);
    }
}
