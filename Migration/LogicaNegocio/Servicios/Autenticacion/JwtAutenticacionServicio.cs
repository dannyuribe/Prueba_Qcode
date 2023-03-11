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
        private readonly IRepositorioGenerico<Logeos> _repositorioLogeos;
        private readonly IJwtTokenServicio _jwtTokenServicio;
        public JwtAutenticacionServicio(
            IRepositorioGenerico<Logeos> repositorioLogeos, 
            IJwtTokenServicio jwtTokenServicio)
        {
            _repositorioLogeos = repositorioLogeos;
            _jwtTokenServicio = jwtTokenServicio;
        }
        public async Task<string> Autenticacion(string correo, string contrasena)
        {
            var usuario = await _repositorioLogeos.ObtenerRegistroPorCondicion(x => x.Correo == correo && x.Contrasena == contrasena && x.estado == true);

            if(usuario == null)
            {
                throw new Exception("Error al Cargar Empleado. No se encontraron registros.");
            }
            return await _jwtTokenServicio.GenerarToken(usuario.IdUsuario);
        }

        public async Task ValidarToken(string token)
        {
            await _jwtTokenServicio.ValidarToken(token);
        }
    }
}
