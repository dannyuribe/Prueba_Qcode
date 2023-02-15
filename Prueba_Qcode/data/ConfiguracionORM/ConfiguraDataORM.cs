using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.ConfiguracionORM
{
    public class ConfiguraDataORM
    {
        private readonly string? _CadenaConeccion;
        public ConfiguraDataORM(IConfiguration configuracion) 
        {
            _CadenaConeccion = configuracion.GetConnectionString("MySqlConnection")
        }

        public IDbConnection GetConnection() 
        {
            IDbConnection _Coneccion = new MySqlConnection(_CadenaConeccion);
            if (_Coneccion.State == ConnectionState.Closed)
            {
                _Coneccion.Open();
            }
            return _Coneccion;
        }
    }
}
