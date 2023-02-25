using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qcode.Datos.Modelos
{
    [Table("Empleados")]
    public class Empleado
    {
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
    }
}
