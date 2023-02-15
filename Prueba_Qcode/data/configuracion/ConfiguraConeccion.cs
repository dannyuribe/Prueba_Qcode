using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.configuracion
{
    public class ConfiguraConeccion
    {
        public ConfiguraConeccion(string cadenaConeccion)
        {
            CadenaConeccion = cadenaConeccion;
        }

        public string CadenaConeccion { get; set; }
    }
}
