using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VideoClub.Datos.Repositorios.Facades;
using VideoClubEntidades.Entidades;

namespace VideoClub.Datos.Repositorios
{
    public class RepositorioProvincias : IRepositorioProvincias
    {
        private readonly SqlConnection conexion;
        public RepositorioProvincias(SqlConnection cn)
        {
            conexion = cn;
        }
        public List<Provincia> GetProvincia()
        {
            try
            {
                List<Provincia> lista = new List<Provincia>();
                string cadenaComando = "SELECT ProvinciaId, NombreProvincia FROM Provincias";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Provincia provincia = ConstruirProvincia(reader);
                    lista.Add(provincia);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private Provincia ConstruirProvincia(SqlDataReader reader)
        {
            return new Provincia
            {
                ProvinciaId = reader.GetInt32(0),
                NombreProvincia = reader.GetString(1)
            };
        }

        public void Borrar(int id)
        {
            try
            {
                string cadenaComando = "DELETE FROM Provincias  WHERE ProvinciaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@id", id);
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

        public bool Existe(Provincia provincia)
        {
            if (provincia.ProvinciaId == 0)
            {
                string cadenaComando = "SELECT ProvinciaId, NombreProvincia FROM Provincias WHERE NombreProvincia=@nombreProvincia";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@nombreProvincia", provincia.NombreProvincia);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {
                string cadenaComando = "SELECT ProvinciaId, NombreProvincia FROM Provincias WHERE NombreProvincia=@nombreProvincia" +
                    " AND ProvinciaId<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@nombreProvincia", provincia.NombreProvincia);
                comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
        }

        public Provincia GetProvinciaPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Guardar(Provincia provincia)
        {
            if (provincia.ProvinciaId == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Provincias VALUES(@nombreProvincia)";
                    SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@nombreProvincia", provincia.NombreProvincia);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, conexion);
                    provincia.ProvinciaId = (int)(decimal)comando.ExecuteScalar();

                }
                catch (Exception e)
                {
                    throw new Exception("Error al intentar guardar el registro");
                }

            }
            else
            {
                try
                {
                    string cadenaComando = "UPDATE Provincias SET NombreProvincia=@nombreProvincia WHERE ProvinciaId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@nombreProvincia", provincia.NombreProvincia);
                    comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw new Exception("Error al intentar modificar el registro");
                }

            }
        }
    }
}
