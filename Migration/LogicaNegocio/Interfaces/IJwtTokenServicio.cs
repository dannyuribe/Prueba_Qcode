using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.BusinessLogic.Interfaces
{
    public interface IJwtTokenServicio
    {
        string GenerarToken(string IdEmpleado);
    }
}
