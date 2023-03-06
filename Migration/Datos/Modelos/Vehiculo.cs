using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Qcode.Datos.Modelos
{
    [Table("Vehiculos")]
    public class Vehiculo
    {
        [Key]
        public string SerialVehiculo { get; set; }
        [StringLength(10)]
        public string Placa { get; set; }
        [StringLength(20)]
        public string Marca { get; set; }
        public int Modelo { get; set; }
        public DateTime FechaCrea { get; set; }
        public bool Activo { get; set; }
        [Column(TypeName ="decimal(53,1)")]
        public decimal Costo { get; set; }
        [StringLength(200)]
        public string rutaImagen { get; set; }
    }
}
