using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Datos.Repositorios.Facades;
using VideoClubEntidades.DTOs.Localidad;
using VideoClubEntidades.Entidades;

namespace VideoClub.Datos.Repositorios
{
    public class RepositorioLocalidades : IRepositorioLocalidades
    {
        private readonly SqlConnection sqlConnection;

        private SqlConnection sqlConnection1;

        public RepositorioLocalidades(SqlConnection conexion)
        {
            sqlConnection = conexion;


        }



        public List<LocalidadListDto> GetLista()
        {
            List<LocalidadListDto> lista = new List<LocalidadListDto>();
            try
            {
                string cadenaComando = "SELECT LocalidadId, NombreLocalidad, NombreProvincia FROM Localidades" +
                    " INNER JOIN Provincias On Localidades.ProvinciaId=Provincias.ProvinciaId";
                SqlCommand comando = new SqlCommand(cadenaComando, sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var localidadDto = ConstruirLocalidadDto(reader);
                    lista.Add(localidadDto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer las localidades");
            }
        }

        public void Guardar(Localidad localidad)
        {
            if (localidad.LocalidadId == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Localidades VALUES(@nombreLocalidad, @provinciaId)";
                    SqlCommand comando = new SqlCommand(cadenaComando, sqlConnection);
                    comando.Parameters.AddWithValue("@nombreLocalidad", localidad.NombreLocalidad);
                    comando.Parameters.AddWithValue("@provinciaId", localidad.Provincia.ProvinciaId);
                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, sqlConnection);
                    localidad.LocalidadId = (int)(decimal)comando.ExecuteScalar();

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
            else
            {
                try
                {
                    string cadenaComando = "UPDATE Localidades SET NombreLocalidad=@nombreLocalidad, ProvinciaId=@provinciaId" +
                        " WHERE LocalidadId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, sqlConnection);
                    comando.Parameters.AddWithValue("@nombreLocalidad", localidad.NombreLocalidad);
                    comando.Parameters.AddWithValue("@provinciaId", localidad.Provincia.ProvinciaId);
                    comando.Parameters.AddWithValue("@id", localidad.LocalidadId);
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
        }
        public bool Existe(Localidad localidad)
        {
            try
            {
                if (localidad.LocalidadId == 0)
                {
                    string cadenaComando = "SELECT * FROM Localidades WHERE NombreLocalidad=@nombreLocalidad " +
                        "AND ProvinciaId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, sqlConnection);
                    comando.Parameters.AddWithValue("@nombreLocalidad", localidad.NombreLocalidad);
                    comando.Parameters.AddWithValue("@id", localidad.Provincia.ProvinciaId);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
                else
                {
                    string cadenaComando = "SELECT * FROM Localidades WHERE NombreLocalidad=@nombreLocalidad " +
                        "AND ProvinciaId=@id AND LocalidadId<>@localidadId";
                    SqlCommand comando = new SqlCommand(cadenaComando, sqlConnection);
                    comando.Parameters.AddWithValue("@nombreLocalidad", localidad.NombreLocalidad);
                    comando.Parameters.AddWithValue("@id", localidad.Provincia.ProvinciaId);
                    comando.Parameters.AddWithValue("@localidadId", localidad.LocalidadId);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        private LocalidadListDto ConstruirLocalidadDto(SqlDataReader reader)
        {
            LocalidadListDto localidadDto = new LocalidadListDto();
            localidadDto.LocalidadId = reader.GetInt32(0);
            localidadDto.NombreLocalidad = reader.GetString(1);
            localidadDto.NombreProvincia = reader.GetString(2);
            return localidadDto;

        }

        public void Borrar(int localidadId)
        {
            try
            {
                string cadenaComando = "DELETE FROM Localidades WHERE LocalidadId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, sqlConnection);
                comando.Parameters.AddWithValue("@id", localidadId);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                if (e.Message.Contains("REFERENCE"))
                {
                    throw new Exception("Registro con datos asociados... Baja denegada");
                }
                throw new Exception(e.Message);
            }
        }


    }
}
