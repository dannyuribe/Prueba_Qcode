using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.BusinessLogic.Interfaces
{
    public interface IJwtTokenServicio
    {
        Task<string> GenerarToken(string IdEmpleado);
    }
}
