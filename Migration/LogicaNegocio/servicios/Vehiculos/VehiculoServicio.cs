using ClosedXML.Excel;
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
    public class VehiculoServicio : IVehiculoServicio
    {
        private readonly IRepositorioGenerico<Vehiculo> _repositorioVehiculo;

        public VehiculoServicio(IRepositorioGenerico<Vehiculo> repositorioVehiculo)
        {
            
            _repositorioVehiculo = repositorioVehiculo;
        }

        public async Task AgregarVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo == null)
            {
                throw new Exception("error al Guardar, no se encontraron datos.");
            }
            
            vehiculo.Costo= CalcularVehiculoCosto(vehiculo);
            vehiculo.FechaCrea = DateTime.Now;

            await _repositorioVehiculo.Agregar(vehiculo);
        }

        private decimal CalcularVehiculoCosto(Vehiculo vehiculo)
        {
            double costo = 200000;
            int dia = vehiculo.FechaCrea.Day;
            
            if(dia % 2 == 0)
            {
                costo += costo * (0.05);
            }

            if(int.Parse(vehiculo.Modelo)<=1997) 
            {
                costo += costo * (0.2);
            }
            return (decimal)costo;
        }

        public async Task CargarVehiculos(Stream archivoExcel)
        {
            try
            {
                using var workbook = new XLWorkbook(archivoExcel);
                IXLWorksheet worksheet = workbook.Worksheet(1);
                if (worksheet == null)
                {
                    throw new Exception("El archivo Excel no contiene hojas de trabajo.");
                }
                int filaInicial = 2;
                int filaFinal = worksheet.LastRowUsed().RowNumber();

                List<Vehiculo> vehiculos = new();
                for (int i = filaInicial; i <= filaFinal; i++)
                {
                    Vehiculo vehiculo = new()
                    {
                        SerialVehiculo = worksheet.Cell(i, 1).Value.ToString() ?? string.Empty,
                        Placa = worksheet.Cell(i, 2).Value.ToString() ?? string.Empty,
                        Marca = worksheet.Cell(i, 3).Value.ToString() ?? string.Empty,
                        RutaImagen = worksheet.Cell(i, 5).Value.ToString() ?? string.Empty,
                        Modelo = worksheet.Cell(i, 4).Value.ToString() ?? string.Empty,
                        FechaCrea = DateTime.Now,
                        Activo = true,
                        Costo = 200000 
                    };
                    vehiculo.Costo= CalcularVehiculoCosto(vehiculo);
                    vehiculos.Add(vehiculo);
                }


                using var transacion = await _repositorioVehiculo.BeginTransaction();

                foreach (Vehiculo vehiculo in vehiculos)
                {
                    var vehiculoAux = await _repositorioVehiculo.ObtenerPorId(vehiculo.SerialVehiculo);

                    if (vehiculoAux == null)
                    {
                        await _repositorioVehiculo.Agregar(vehiculo);
                    }
                    else
                    {
                        vehiculo.FechaCrea = DateTime.Now;
                        await _repositorioVehiculo.Actualizar(vehiculo);
                    }
                }
                var vehiculosActualizar =
                    await _repositorioVehiculo.ObtenerRegistrosPorCondicion(
                        v => !vehiculos.Contains(v));

                foreach (Vehiculo vehiculo in vehiculosActualizar)
                {
                    vehiculo.Activo = false;
                    vehiculo.FechaCrea = DateTime.Now;

                    await _repositorioVehiculo.Actualizar(vehiculo);
                }

                transacion.CommitAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Error en los datos ingresados.");
            }
        }

        public async Task EditarVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo == null)
            {
                throw new Exception("error al Actualizar,no se encontraron datos.");
            }
            await _repositorioVehiculo.Actualizar(vehiculo);
        }

        public async Task<Vehiculo> ObtenerVehiculoPorSerial(string serialVehiculo)
        {
            Vehiculo vehiculo = await _repositorioVehiculo.ObtenerPorId(serialVehiculo);
            return vehiculo;
        }
       
    }
}
