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
    public class RepositorioSoportes:IRepositorioSoportes
    {
        private readonly SqlConnection conexion;
        public RepositorioSoportes(SqlConnection cn)
        {
            conexion = cn;
        }

        public void Borrar(int id)
        {
            try
            {
                string cadenaComando = "DELETE FROM Soportes WHERE SoporteId=@id";
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

        public bool Existe(Soporte soporte)
        {
            if (soporte.SoporteId == 0)
            {
                string cadenaComando = "SELECT SoporteId, Descripcion FROM Soportes WHERE Descripcion=@descripcion";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@descripcion", soporte.Descripcion);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {
                string cadenaComando = "SELECT SoporteId, Descripcion FROM Soportes WHERE Descripcion=@descripcion" +
                    " AND SoporteId<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@descripcion", soporte.Descripcion);
                comando.Parameters.AddWithValue("@id", soporte.SoporteId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
        }

        public List<Soporte> GetSoporte()
        {
            try
            {
                List<Soporte> lista = new List<Soporte>();
                string cadenaComando = "SELECT SoporteId, Descripcion FROM Soportes";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Soporte soporte = ConstruirSoporte(reader);
                    lista.Add(soporte);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private Soporte ConstruirSoporte(SqlDataReader reader)
        {
            return new Soporte
            {
                SoporteId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }

        public Soporte GetSoportePorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Soporte soporte)
        {
            if (soporte.SoporteId == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Soportes VALUES(@descripcion)";
                    SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@descripcion", soporte.Descripcion);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, conexion);
                    soporte.SoporteId = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE Soportes SET Descripcion=@descripcion WHERE SoporteId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@descripcion", soporte.Descripcion);
                    comando.Parameters.AddWithValue("@id", soporte.SoporteId);
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
