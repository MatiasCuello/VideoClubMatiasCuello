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
    public class RepositorioCalificaciones : IRepositorioCalificaciones
    {
        private readonly SqlConnection conexion;
        public RepositorioCalificaciones(SqlConnection cn)
        {
            conexion = cn;
        }
        public List<Calificacion> GetCalificacion()
        {
            try
            {
                List<Calificacion> lista = new List<Calificacion>();
                string cadenaComando = "SELECT CalificacionId, Descripcion FROM Calificaciones";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Calificacion calificacion = ConstruirCalificacion(reader);
                    lista.Add(calificacion);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private Calificacion ConstruirCalificacion(SqlDataReader reader)
        {
            return new Calificacion
            {
                CalificacionId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }

        public Calificacion GetCalificacionPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Calificacion calificacion)
        {
            if (calificacion.CalificacionId == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Calificaciones VALUES(@descripcion)";
                    SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@descripcion", calificacion.Descripcion);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, conexion);
                    calificacion.CalificacionId = (int)(decimal)comando.ExecuteScalar();

                }
                catch (Exception e)
                {
                    throw new Exception("Error al intentar guardar una calificacion");
                }

            }
            else
            {
                try
                {
                    string cadenaComando = "UPDATE Calificaciones SET Descripcion=@descripcion WHERE CalificacionId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@descripcion", calificacion.Descripcion);
                    comando.Parameters.AddWithValue("@id", calificacion.CalificacionId);
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw new Exception("Error al intentar modificar una calificacion");
                }

            }
        }
        public void Borrar(int id)
        {
            try
            {
                string cadenaComando = "DELETE FROM Calificaciones WHERE CalificacionId=@id";
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

        public bool Existe(Calificacion calificacion)
        {
            if (calificacion.CalificacionId == 0)
            {
                string cadenaComando = "SELECT CalificacionId, Descripcion FROM Calificaciones WHERE Descripcion=@descripcion";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@descripcion", calificacion.Descripcion);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {
                string cadenaComando = "SELECT CalificacionId, Descripcion FROM Calificaciones WHERE Descripcion=@descripcion" +
                    " AND CalificacionId<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@descripcion", calificacion.Descripcion);
                comando.Parameters.AddWithValue("@id", calificacion.CalificacionId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;

            }

        }
    }
}
