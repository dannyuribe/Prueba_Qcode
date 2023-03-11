using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Qcode.Datos.Modelos
{
    public class ActivarUsuarioLogeo
    {
        [Key]
        public string IdUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }
        [Required]
        [StringLength(50)]
        public string Correo { get; set; }
        [StringLength(50)]
        public string Telefono { get; set; }
        [Required]
        public DateTime FechaCrea { get; set; }
        [Required]
        [StringLength(50)]
        public string Logeo { get; set; }
        [Required]
        [StringLength(200)]
        public string Contrasena { get; set; }
        public bool estado { get; set; }
        [JsonIgnore]
        public string? CodigoActivacion { get; set; }
    }
}
