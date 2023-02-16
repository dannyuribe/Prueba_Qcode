using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AccesoDatos.Modelos
{
    public class Propietario
    {
        public Propietario()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }
        public string IdPropietario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaModifica { get; set; }
        [Computed]
        [JsonIgnore]
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
