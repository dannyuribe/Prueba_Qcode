using Qcode.BusinessLogic.Interfaces;
using Qcode.Datos.Modelos;
using Qcode.Datos.repositorio.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.BusinessLogic.Servicios.RegistroUsuarioLogeos
{
    public class LogeoServicio : ILogeoServicio
    {
        private readonly IRepositorioGenerico<Logeos> _RepositorioLogeos;
        private readonly IRepositorioGenerico<Usuario> _RepositorioUsuarios;
        public LogeoServicio(
            IRepositorioGenerico<Logeos> repositorioLogeos, 
            IRepositorioGenerico<Usuario> repositorioUsuarios)
        {
            _RepositorioLogeos = repositorioLogeos;
            _RepositorioUsuarios = repositorioUsuarios;
        }
        public async Task RegistrarUsuarioLogeo(Logeos logeo)
        {
            try
            {
                if (logeo == null)
                {
                    throw new Exception("No se encontro informacion.");
                }
                using var transacion = await _RepositorioLogeos.BeginTransaction();

                //validar que el correo no se encuentre registrado
                Usuario usuario = await _RepositorioUsuarios.ObtenerRegistroPorCondicion(
                    x => x.Correo == logeo.Usuario.Correo);

                if(usuario != null)
                {
                    throw new Exception("El Usuario ya se encuentra registrado.");
                }
                await _RepositorioUsuarios.Agregar(logeo.Usuario);

                Logeos Aseguralogeo = new()
                {
                    Logeo = logeo.Logeo,
                    Contrasena = logeo.Contrasena,
                    IdUsuario = logeo.Usuario.IdUsuario,
                    FechaCrea = DateTime.Now
                };
                await _RepositorioLogeos.Agregar(Aseguralogeo);
                await transacion.CommitAsync();
            }
            catch (Exception ex) 
            {
                throw new Exception("Error");
            }

            
        }

    }
}
