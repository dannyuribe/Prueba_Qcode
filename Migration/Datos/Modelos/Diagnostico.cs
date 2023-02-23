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
    [Table ("Diagnosticos")]
    public class Diagnostico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdDiagnostico { get; set; }

        [ForeignKey("Reparaciones")]
        public long IdReparacion { get; set; }

        [ForeignKey("Empleados")]
        public string IdEmpleado { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set;}
        [StringLength(100)]
        public string Resultados { get; set;}
        [Required]
        public DateTime FechaCrea { get; set; }

        [JsonIgnore]
        protected virtual Reparacion Reparaciones { get; set; }
        [JsonIgnore]
        protected virtual Empleado Empleados { get; set; }
    }
}
    