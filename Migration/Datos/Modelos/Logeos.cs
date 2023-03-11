using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qcode.Datos.Modelos
{
    [Table("Logeos")]
    public class Logeos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLogeo { get; set; }
        [Required]
        public string IdUsuario { get; set; }
        [Required]
        [StringLength(50)]
        public string Logeo { get; set; }
        [Required]
        [StringLength(200)]
        public string Contrasena { get; set; }
        [Required]
        public DateTime FechaCrea { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }

    }
}
