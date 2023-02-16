using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AccesoDatos.Modelos
{
    public class Diagnostico
    {
        public Diagnostico()
        {
            Empleado = new HashSet<Empleado>();
        }
        public long IdDiagnostico { get; set; }
        public long IdReparacion { get; set; }
        public string IdEmpleado { get; set; }
        public string Descripcion { get; set;}
        public string Resultados { get; set;}
        public DateTime fechaCrea { get; set; }

        [Computed]
        [JsonIgnore]
        public virtual Reparacion Reparaciones { get; set; }
        [Computed]
        [JsonIgnore]
        public virtual Empleado Empleado { get; set; }
    }
}
