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
    [Table("Logeos")]
    public class Logeos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int IdLogeo { get; set; }
        public string IdUsuario { get; set; }
        [Required]
        [StringLength(50)]
        public string Correo { get; set; }
        [Required]
        [StringLength(200)]
        public string Contrasena { get; set; }
        public bool estado { get; set; }
        [JsonIgnore]
        public DateTime FechaCrea { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }
    }
}