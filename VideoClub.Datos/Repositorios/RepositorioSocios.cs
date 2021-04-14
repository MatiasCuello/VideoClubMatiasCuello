using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Datos.Repositorios.Facades;
using VideoClubEntidades.DTOs;

namespace VideoClub.Datos.Repositorios
{
    public class RepositorioSocios : IRepositorioSocios
    {
        private readonly SqlConnection _sqlConnection;
        public RepositorioSocios(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public List<SocioListDto> GetLista()
        {
            List<SocioListDto> lista = new List<SocioListDto>();
            try
            {
                string cadenaComando = "SELECT SocioId, Nombre, Apellido, NombreProvincia, NombreLocalidad FROM Socios" +
                    " INNER JOIN Provincias ON Socios.ProvinciaId=Provincias.ProvinciaId " +
                    "INNER JOIN Localidades ON Socios.LocalidadId=Localidades.LocalidadId";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var socioListDto = ConstruirSocioListDto(reader);
                    lista.Add(socioListDto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer los socios");
            }
        }

        private SocioListDto ConstruirSocioListDto(SqlDataReader reader)
        {
            return new SocioListDto
            {
                SocioId = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Apellido = reader.GetString(2),
                Provincia = reader.GetString(3),
                Localidad= reader.GetString(4)
            };
        }
    }
}
