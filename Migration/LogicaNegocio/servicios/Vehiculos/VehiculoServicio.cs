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
    public class VehiculoServicio: IVehiculoServicio
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
            await _repositorioVehiculo.Agregar(vehiculo);
        }

        public async Task<Vehiculo> ObtenerVehiculoPorSerial(string serialVehiculo)
        {
            Vehiculo vehiculo = await _repositorioVehiculo.ObtenerPorId(serialVehiculo);
            return vehiculo;
        }

        public async Task<int> CargarVehiculos(Stream archivoExcel)
        {
            try
            {
                List<Vehiculo> registros = new();

                using var workbook = new XLWorkbook(archivoExcel);

                IXLWorksheet worksheet = workbook.Worksheet(1);

                if (worksheet == null)
                {
                    throw new Exception("El archivo Excel no contiene hojas de trabajo.");
                }

                int filaInicial = 2;
                int filaFinal = worksheet.LastRowUsed().RowNumber();


                for (int i = filaInicial; i <= filaFinal; i++)
                {
                    Vehiculo vehiculo = new();

                    vehiculo.SerialVehiculo =
                        worksheet.Cell(i, 1).Value.ToString() ?? string.Empty;                                
                   
                    vehiculo.Placa = 
                        worksheet.Cell(i, 2).Value.GetText() ?? string.Empty;

                    vehiculo.FechaCrea = DateTime.Now;

                    registros.Append(vehiculo);
                }

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en los datos ingresados.");
            }
        }

        public async Task EditarVehiculo(Vehiculo vehiculo)
        {
            if(vehiculo == null)
            {
                throw new Exception("error al Actualizar,no se encontraron datos.");
            }
            await _repositorioVehiculo.Actualizar(vehiculo);
        }
    }
}
