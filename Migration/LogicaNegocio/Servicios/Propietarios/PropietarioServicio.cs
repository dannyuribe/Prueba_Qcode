using Qcode.BusinessLogic.Interfaces;
using Qcode.Datos.Modelos;
using Qcode.Datos.repositorio.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.BusinessLogic.Servicios.Propietarios
{
    public class PropietarioServicio :IPropietarioServicio
    {
        private readonly IRepositorioGenerico<Propietario> _repositorioPropietario;

        public PropietarioServicio(IRepositorioGenerico<Propietario> repositorioVehiculo)
        {
            _repositorioPropietario = repositorioVehiculo;
        }

        public async Task AgregarPropietario(Propietario propietario)
        {

           await _repositorioPropietario.Agregar(propietario);
        }
    }
}
