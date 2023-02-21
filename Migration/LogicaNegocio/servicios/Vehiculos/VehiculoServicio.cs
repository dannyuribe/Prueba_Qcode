using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Modelos;
using Datos.Contexto;
using Datos.repositorio.Vehiculos;

namespace LogicaNegocio.servicios.Vehiculos
{
    public class VehiculoServicio
    {
        private readonly VehiculoRepositorio _vehiculoRepositorio;

        public VehiculoServicio()
        {
            _vehiculoRepositorio = new VehiculoRepositorio();
        }


        public Task<Vehiculo> ObtenerPorSerialVehiculo(string serialVehiculo)
        {
            return _vehiculoRepositorio.ObtenerVehiculo(serialVehiculo);
        }
    }
}
