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
    public class RepositorioEstados : IRepositorioEstados
    {
        private readonly SqlConnection conexion;
        public RepositorioEstados(SqlConnection cn)
        {
            conexion = cn;
        }
        public List<Estado> GetEstado()
        {
            try
            {
                List<Estado> lista = new List<Estado>();
                string cadenaComando = "SELECT EstadoId, Descripcion FROM Estados";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Estado estado = ConstruirEstado(reader);
                    lista.Add(estado);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private Estado ConstruirEstado(SqlDataReader reader)
        {
            return new Estado
            {
                EstadoId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }

        public void Borrar(int id)
        {
            try
            {
                string cadenaComando = "DELETE FROM Estados WHERE EstadoId=@id";
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

        public bool Existe(Estado estado)
        {

            if (estado.EstadoId == 0)
            {
                string cadenaComando = "SELECT EstadoId, Descripcion FROM Estados WHERE Descripcion=@descripcion";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@descripcion", estado.Descripcion);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {
                string cadenaComando = "SELECT EstadoId, Descripcion FROM Estados WHERE Descripcion=@descripcion" +
                    " AND EstadoId<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@descripcion", estado.Descripcion);
                comando.Parameters.AddWithValue("@id", estado.EstadoId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;

            }

        }

        public Soporte GetEstadoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Estado estado)
        {
            if (estado.EstadoId == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Estados VALUES(@descripcion)";
                    SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@descripcion", estado.Descripcion);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, conexion);
                    estado.EstadoId = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE Estados SET Descripcion=@descripcion WHERE EstadoId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@descripcion", estado.Descripcion);
                    comando.Parameters.AddWithValue("@id", estado.EstadoId);
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

