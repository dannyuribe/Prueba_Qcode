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
    [Table("Propietarios")]
    public class Propietario
    {
        public Propietario()
        {
            Vehiculos= new HashSet<Vehiculo>();
        }
        [Key]
        public string IdPropietario { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }
        [StringLength(50)]
        public string Telefono { get; set; }
        [StringLength(50)]
        public string Correo { get; set; }
        [StringLength(50)]
        public string Direccion { get; set; }
        [Required]
        public DateTime FechaCrea { get; set; }
        [JsonIgnore]
        protected virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
