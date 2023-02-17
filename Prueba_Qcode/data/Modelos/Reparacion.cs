using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AccesoDatos.Modelos
{
    public class Reparacion
    {
        public Reparacion()
        {
            Diagnosticos = new HashSet<Diagnostico>();
        }
        public long IdReparacion { get; set; }
        public long IdEstadoReparacion { get; set; }
        public string SerialVehiculo { get; set; }
        
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        [Computed]
        [JsonIgnore]
        public virtual Vehiculo Vehiculo { get; set; }
        [Computed]
        [JsonIgnore]
        public virtual EstadoReparacion EstadoReparacion { get; set; }
        [Computed]
        [JsonIgnore]
        public virtual ICollection<Diagnostico> Diagnosticos { get; set; }
    }
}
