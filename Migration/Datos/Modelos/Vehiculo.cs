using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AccesoDatos.Modelos
{
    [Table("Vehiculos")]
    public class Vehiculo
    {
        [Key]
        public string SerialVehiculo { get; set; }
        [ForeignKey("Propietarios")]
        public string IdPropietario { get; set; }
        [Required]
        [StringLength(10)]
        public string Placa { get; set; }
        [StringLength(20)]
        public string Marca { get; set; }
        [StringLength(20)]
        public string Modelo { get; set; }
        [Required]
        public DateTime FechaCrea { get; set; }

        public virtual Propietario Propietarios { get; set; }
        public virtual ICollection<Reparacion> Reparaciones { get;set; }

    }
}
