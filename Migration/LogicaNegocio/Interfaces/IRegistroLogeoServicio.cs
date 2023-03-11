using Qcode.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.BusinessLogic.Interfaces
{
    public interface IRegistroLogeoServicio
    {
        Task RegistrarUsuarioLogeo(ActivarUsuarioLogeo logeo);
        Task ActivarUsuarioLogeo(string correo,string codigoActivacion);
        Task RecuperarContrasena(string correo);
    }
}
