using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

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
        [Required]
        public bool Activo { get; set; }
        [StringLength(200)]
        public string RutaImagen { get; set; }
        [Column(TypeName ="decimal(53,1)")]
        public decimal Costo { get; set; }
    }
}
