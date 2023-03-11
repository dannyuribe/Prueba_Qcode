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
        public string Logeo { get; set; }
        [Required]
        [StringLength(200)]
        public string Contrasena { get; set; }
        [JsonIgnore]
        public DateTime FechaCrea { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }

    }
}
/*{
  "logeo": "q",
  "contrasena": "1",
  "usuario": {
    "idUsuario": "1151",
    "idTipoUsuario": 1,
    "nombre": "Danny",
    "apellido": "Uribe",
    "correo": "Danny.uribeh@gmail.com",
    "telefono": "1234567",
    "fechaCrea": "2023-03-11T18:53:03.598Z"
  }
}*/