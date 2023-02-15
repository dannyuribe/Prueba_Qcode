using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.ConfiguracionORM
{
    public static class DataFactoryORM
    {
        public static ConfiguraDataORM ConfiguraDataOrm { get; private set; }
        public static void Configura(IConfiguration configuracion)
        {
            ConfiguraDataOrm = new ConfiguraDataORM(configuracion);
        }
        
    }
}
