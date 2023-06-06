using System.Configuration;

namespace Datos.Conexion
{
    public class ConexionMaestra
    {
        public static string CadenaConexionMaestra = ConfigurationManager.ConnectionStrings["ConexionSQLServer"].ToString();
    }
}
