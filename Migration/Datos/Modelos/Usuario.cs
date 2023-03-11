using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Qcode.Datos.Modelos
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public string IdUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellido { get; set;}
        [Required]
        [StringLength(50)]
        public string Correo { get; set; }
        [StringLength(50)]
        public string Telefono { get; set; }
        [Required]
        public DateTime FechaCrea { get; set;}
        [JsonIgnore]
        [ForeignKey("IdTipoUsuario")]
        protected virtual TipoUsuario TipoUsuarios { get; set; }
    }
}
