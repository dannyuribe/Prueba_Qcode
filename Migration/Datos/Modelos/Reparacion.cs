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
    [Table("Reparaciones")]
    public class Reparacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdReparacion { get; set; }


        [Required]
        public DateTime FechaCrea { get; set; }
        public DateTime FechaSale { get; set; }


        [ForeignKey("EstadoReparaciones")]
        public long IdEstadoReparacion { get; set; }
        [ForeignKey("Vehiculos")]
        public string SerialVehiculo { get; set; }


        public virtual Vehiculo Vehiculos { get; set; }
        public virtual EstadoReparacion EstadoReparaciones { get; set; }
        public virtual ICollection<Diagnostico> Diagnosticos { get; set; }
    }
}
