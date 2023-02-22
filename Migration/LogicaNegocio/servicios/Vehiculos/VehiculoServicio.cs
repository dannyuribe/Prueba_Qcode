using Qcode.BusinessLogic.Interfaces;
using Qcode.Datos.Modelos;
using Qcode.Datos.repositorio.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Qcode.BusinessLogic.servicios.Vehiculos
{
    public class VehiculoServicio:IVehiculoServicio
    {
        private readonly RepositorioGenerico<Vehiculo> _repositorioVehiculo;

        public VehiculoServicio(RepositorioGenerico<Vehiculo> repositorioVehiculo)
        {
            _repositorioVehiculo = repositorioVehiculo;
        }


        public async Task<Vehiculo> ObtenerVehiculoPorSerial(string serialVehiculo)
        {
            Vehiculo vehiculo = await _repositorioVehiculo.ObtenerPorId(serialVehiculo);
            return vehiculo;
        }
    }
}
