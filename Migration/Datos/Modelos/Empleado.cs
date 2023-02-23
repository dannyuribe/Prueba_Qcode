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
    [Table("Empleados")]
    public class Empleado
    {
        public Empleado()
        {
            Diagnosticos = new HashSet<Diagnostico>();
        }
        [Key]
        public string IdEmpleado { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellido { get; set;}
        [Required]
        [StringLength(50)]
        public string Usuario { get; set;}
        [Required]
        [StringLength(200)]
        public string Contrasena { get; set;}
        [Required]
        public DateTime FechaCrea { get; set;}
        [JsonIgnore]
        protected virtual ICollection<Diagnostico> Diagnosticos { get; set; }
    }
}
