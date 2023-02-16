using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AccesoDatos.Modelos
{
    public class EstadoReparacion
    {
        public EstadoReparacion()
        {
            Reparaciones = new HashSet<Reparacion>();
        }
        public long IdEstadoReparacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCrea { get; set; }
        [Computed]
        [JsonIgnore]
        public virtual ICollection<Reparacion> Reparaciones { get; set; }
    }
}
