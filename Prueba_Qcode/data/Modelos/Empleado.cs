using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AccesoDatos.Modelos
{
    public class Empleado
    {
        public string IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set;}
        public string Usuario { get; set;}
        public string Contrasena { get; set;}
        public DateTime FechaCrea { get; set;}
        public DateTime FechaModifica { get; set; }
        [Computed]
        [JsonIgnore]
        public virtual ICollection<Diagnostico> Diagnosticos { get; set; }
    }
}
