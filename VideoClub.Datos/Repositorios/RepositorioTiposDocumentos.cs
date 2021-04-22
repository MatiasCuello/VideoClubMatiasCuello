using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Datos.Repositorios.Facades;
using VideoClubEntidades.Entidades;

namespace VideoClub.Datos.Repositorios
{
    public class RepositorioTiposDocumentos : IRepositorioTiposDocumentos
    {
        private readonly SqlConnection conexion;
        public RepositorioTiposDocumentos(SqlConnection cn)
        {
            conexion = cn;
        }
        public List<TipoDocumento> GetTipoDocumento()
        {
            try
            {
                List<TipoDocumento> lista = new List<TipoDocumento>();
                string cadenaComando = "SELECT TipoDocumentoId, Descripcion FROM TiposDocumentos ";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    TipoDocumento tipoDocumentos = ConstruirTipoDocumento(reader);
                    lista.Add(tipoDocumentos);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        private TipoDocumento ConstruirTipoDocumento(SqlDataReader reader)
        {
            return new TipoDocumento
            {
                TipoDocumentoId= reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }
    }
}
