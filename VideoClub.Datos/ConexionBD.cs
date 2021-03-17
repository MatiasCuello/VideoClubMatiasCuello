using System.Configuration;
using System.Data.SqlClient;

namespace VideoClub.Datos
{
    public class ConexionBD
    {
        private readonly SqlConnection cn;
        public ConexionBD()
        {
            var cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
            cn = new SqlConnection(cadenaConexion);
        }
        public SqlConnection AbrirConexion()
        {
            if (cn.State == System.Data.ConnectionState.Closed)
            {
                cn.Open();
            }
            return cn;
        }

        public void CerrarConexion()
        {
            if (cn.State == System.Data.ConnectionState.Open)
            {
                cn.Close();

            }
        }
    }
}
