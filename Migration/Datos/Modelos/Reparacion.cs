using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Qcode.Datos.Modelos
{
    [Table("Reparaciones")]
    public class Reparacion
    {
        public Reparacion()
        {
            Diagnosticos = new HashSet<Diagnostico>();
        }

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

        [JsonIgnore]
        protected virtual Vehiculo Vehiculos { get; set; }
        [JsonIgnore]
        protected virtual EstadoReparacion EstadoReparaciones { get; set; }
        [JsonIgnore]
        protected virtual ICollection<Diagnostico> Diagnosticos { get; set; }
    }
}
