using Qcode.BusinessLogic.Interfaces;
using Qcode.Datos.Modelos;
using Qcode.Datos.repositorio.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.BusinessLogic.Servicios.RegistroUsuarioLogeos
{
    public class RegistroLogeoServicio : IRegistroLogeoServicio
    {
        private readonly IRepositorioGenerico<Logeos> _RepositorioLogeos;
        private readonly IRepositorioGenerico<Usuario> _RepositorioUsuarios;
        private readonly IRepositorioGenerico<ActivarUsuarioLogeo> _RepositorioActivarUsuarioLogeo;
        public RegistroLogeoServicio(
            IRepositorioGenerico<Logeos> repositorioLogeos, 
            IRepositorioGenerico<Usuario> repositorioUsuarios,
            IRepositorioGenerico<ActivarUsuarioLogeo> repositorioActivarUsuarioLogeo)
        {
            _RepositorioLogeos = repositorioLogeos;
            _RepositorioUsuarios = repositorioUsuarios;
            _RepositorioActivarUsuarioLogeo = repositorioActivarUsuarioLogeo;
        }

        public async Task ActivarUsuarioLogeo(string correo, string codigoActivacion)
        {
            try {
                if (string.IsNullOrEmpty(correo))
                {
                    throw new Exception("Debes ingresar el correo activar.");
                }
                if (string.IsNullOrEmpty(codigoActivacion))
                {
                    throw new Exception("Debes ingresar el codigo de activacion.");
                }
                using var transacion = await _RepositorioActivarUsuarioLogeo.BeginTransaction();
                ActivarUsuarioLogeo activarUsuario =
                    await _RepositorioActivarUsuarioLogeo.ObtenerRegistroPorCondicion(x =>
                        x.Correo == correo &&
                        x.CodigoActivacion == codigoActivacion);

                if (activarUsuario == null)
                {
                    throw new Exception("los datos ingresados son incorrectos.");
                }

                Usuario usuario = new()
                {
                    IdUsuario = activarUsuario.IdUsuario,
                    IdTipoUsuario = activarUsuario.IdTipoUsuario,
                    Nombre = activarUsuario.Nombre,
                    Apellido = activarUsuario.Apellido,
                    Correo = activarUsuario.Correo,
                    Telefono = activarUsuario.Telefono,
                    FechaCrea = DateTime.Now
                };

                Logeos logeo = new()
                {
                    IdUsuario = activarUsuario.IdUsuario,
                    Logeo = activarUsuario.Logeo,
                    Contrasena = activarUsuario.Contrasena,
                    FechaCrea = DateTime.Now
                };
                await _RepositorioUsuarios.Agregar(usuario);
                await _RepositorioLogeos.Agregar(logeo);
                activarUsuario.estado = false;
                await _RepositorioActivarUsuarioLogeo.Actualizar(activarUsuario);
                await transacion.CommitAsync();
            }
            catch(Exception e)
            {
                throw new Exception("Error"+e);
            }
        }

        public Task RecuperarContrasena(string correo)
        {
            throw new NotImplementedException();
        }

        public async Task RegistrarUsuarioLogeo(ActivarUsuarioLogeo registroLogeo)
        {
            if (registroLogeo == null)
            {
                throw new Exception("No se encontro informacion.");
            }

            //validar que el correo no se encuentre registrado
            Usuario usuario = await _RepositorioUsuarios.ObtenerRegistroPorCondicion(
                x => x.Correo == registroLogeo.Correo);

            if(usuario != null)
            {
                throw new Exception("El Usuario ya se encuentra registrado.");
            }

            registroLogeo.CodigoActivacion = GenerarCodigoVerificacion();

            if (enviarEmailCodigoVerificacion(registroLogeo))
            {                 
                await _RepositorioActivarUsuarioLogeo.Agregar(registroLogeo);
            }            
        }

        //modificar estos metodos en una clase estatica 
        private string GenerarCodigoVerificacion()
        {
            return "Asdf";
        }

        private bool enviarEmailCodigoVerificacion(ActivarUsuarioLogeo registroLogeo)
        {
            try 
            {
                if (string.IsNullOrEmpty(registroLogeo.Correo))
                {
                    throw new Exception("Debes ingresar un correo valido.");
                }
                using SmtpClient cliente = new("smtp.gmail.com", 587);
                cliente.UseDefaultCredentials = false;
                cliente.EnableSsl = true;
                cliente.Credentials = new NetworkCredential("dannyuribe.fullstack@gmail.com", "ivescdnpuoevsedc");
                //pass smtp: ivescdnpuoevsedc
                //pass correo: Desarrollo.2023
                // Configurar el correo electrónico
                using MailMessage message = new();
                message.From = new MailAddress("dannyuribe.fullstack@gmail.com");
                message.To.Add(registroLogeo.Correo);
                message.Subject = "Código de verificación";
                message.Body = "Su código de verificación es: " + registroLogeo.CodigoActivacion;

                // Enviar el correo electrónico
                cliente.Send(message);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }            
        }
    }
}
