using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Qcode.BusinessLogic.Interfaces;
using Qcode.Datos.Modelos;
using Qcode.Datos.repositorio.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.BusinessLogic.Servicios.Reparaciones
{
    public class ReparacionesServicio : IReparacionesServicio
    {
        private readonly IRepositorioGenerico<Reparacion> _repositorioReparacion;

        public ReparacionesServicio(IRepositorioGenerico<Reparacion> repositorioReparacion)
        {
            _repositorioReparacion= repositorioReparacion;
        }

        public async Task<int>  AgregarReparaciones(Stream archivoExcel)
        {
            try
            {
                List<Reparacion> registros = new();

                using var workbook = new XLWorkbook(archivoExcel);
            
                IXLWorksheet worksheet = workbook.Worksheet(1);

                if (worksheet == null)
                {
                    throw new Exception("El archivo Excel no contiene hojas de trabajo.");
                }

                int filaInicial = 2;
                int filaFinal = worksheet.LastRowUsed().RowNumber();
                

                for (int i = filaInicial; i<=filaFinal;i++)
                {
                    Reparacion reparacion = new();
                
                    reparacion.FechaCrea=DateTime.Now;                
                    reparacion.SerialVehiculo = 
                        worksheet.Cell(i, 1).Value.ToString() ?? string.Empty;
                    reparacion.IdEstadoReparacion = 
                        int.Parse(worksheet.Cell(i, 2).Value.ToString() ?? string.Empty);                       
                
                    registros.Append(reparacion);
                }

            return 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en los datos ingresados.");
            }
        }

    }
}
