using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Qcode.Datos.Modelos
{
    [Table("Vehiculos")]
    public class Vehiculo
    {
        [Key]
        public string SerialVehiculo { get; set; }
        [Required]
        [StringLength(10)]
        public string Placa { get; set; }
        [StringLength(20)]
        public string Marca { get; set; }
        [StringLength(20)]
        public string Modelo { get; set; }
        [Required]
        public DateTime FechaCrea { get; set; }
        [StringLength(200)]
        public string RutaImagen { get; set; }
    }
}
