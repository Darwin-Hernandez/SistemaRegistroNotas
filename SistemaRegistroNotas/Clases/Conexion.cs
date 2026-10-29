using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaRegistroNotas.Clases
{
    // Esta clase centraliza la conexión con SQL Server.
    public class Conexion
    {
        // Lee la cadena de conexión definida en App.config.
        private static readonly string cadena =
            System.Configuration.ConfigurationManager
            .ConnectionStrings["ConexionBD"].ConnectionString;

        // Devuelve una conexión nueva a la base de datos.
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}
