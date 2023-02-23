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
    [Table("EstadoReparacion")]
    public class EstadoReparacion
    {
        public EstadoReparacion()
        {
            Reparaciones= new HashSet<Reparacion>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdEstadoReparacion { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required]
        public DateTime FechaCrea { get; set; }
        [JsonIgnore]
        public virtual ICollection<Reparacion> Reparaciones { get; set; }
    }
}
