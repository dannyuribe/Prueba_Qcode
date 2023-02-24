using Qcode.BusinessLogic.Interfaces;
using Qcode.Datos.Modelos;
using Qcode.Datos.repositorio.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.BusinessLogic.Servicios.Autenticacion
{
    public class JwtAutenticacionServicio : IJwtAutenticacionServicio
    {
        private readonly IRepositorioGenerico<Empleado> _repositorioEmpleado;
        private readonly IJwtTokenServicio _jwtTokenServicio;
        public JwtAutenticacionServicio(IRepositorioGenerico<Empleado> repositorioEmpleado, IJwtTokenServicio jwtTokenServicio)
        {
            _repositorioEmpleado = repositorioEmpleado;
            _jwtTokenServicio = jwtTokenServicio;
        }
        public string Autenticacion(string usuario, string contrasena)
        {
            var Empleado = _repositorioEmpleado.ObtenerRegistroPorCondicion(x => x.Usuario == usuario && x.Contrasena == contrasena);

            if(Empleado== null)
            {
                return null;
            }
            return _jwtTokenServicio.GenerarToken(Empleado.Result.IdEmpleado);
        }
    }
}
