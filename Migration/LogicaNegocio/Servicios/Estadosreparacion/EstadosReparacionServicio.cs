using Qcode.BusinessLogic.Interfaces;
using Qcode.Datos.Modelos;
using Qcode.Datos.repositorio.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.BusinessLogic.Servicios.Estadosreparacion
{
    public class EstadosReparacionServicio : IEstadosReparacionServicio
    {
        private readonly RepositorioGenerico<EstadoReparacion> _repositorioEstadoRepacion;
        public EstadosReparacionServicio(RepositorioGenerico<EstadoReparacion> repositorioEstadoRepacion)
        {
            _repositorioEstadoRepacion = repositorioEstadoRepacion;
        }

        public async Task Actualizar(EstadoReparacion estadoReparacion)
        {
            await _repositorioEstadoRepacion.Actualizar(estadoReparacion);
        }

        public async Task Agregar(EstadoReparacion estadoReparacion)
        {
            await _repositorioEstadoRepacion.Agregar(estadoReparacion);
        }
    }
}
