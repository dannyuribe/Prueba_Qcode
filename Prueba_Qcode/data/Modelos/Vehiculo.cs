using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AccesoDatos.Modelos
{
    public class Vehiculo
    {
        public Vehiculo()
        {
            Reparaciones = new HashSet<Reparacion>();
        }
        public string SerialVehiculo { get; set; }
        public string IdPropietario { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaModifica { get; set; }
        [Computed]
        [JsonIgnore]
        public virtual Propietario Propietario { get; set; }
        [Computed]
        [JsonIgnore]
        public virtual ICollection<Reparacion> Reparaciones { get;set; }

    }
}
