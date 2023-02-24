using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.BusinessLogic.Interfaces
{
    public interface IJwtAutenticacionServicio
    {
        string Autenticacion(string usuario, string contrasena);
    }
}
