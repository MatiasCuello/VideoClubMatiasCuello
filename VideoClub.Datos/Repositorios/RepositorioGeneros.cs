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
    public class RepositorioGeneros : IRepositorioGeneros
    {
        private readonly SqlConnection conexion;
        public RepositorioGeneros(SqlConnection cn)
        {
            conexion = cn;
        }
        public List<Genero> GetGenero()
        {
            try
            {
                List<Genero> lista = new List<Genero>();
                string cadenaComando = "SELECT GeneroId, Descripcion FROM Generos";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Genero genero = ConstruirGenero(reader);
                    lista.Add(genero);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private Genero ConstruirGenero(SqlDataReader reader)
        {
            return new Genero
            {
                GeneroId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }
        public void Borrar(int id)
        {
            try
            {
                string cadenaComando = "DELETE FROM Generos WHERE GeneroId=@id";
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

        public bool Existe(Genero genero)
        {
            if (genero.GeneroId == 0)
            {
                string cadenaComando = "SELECT GeneroId, Descripcion FROM Generos WHERE Descripcion=@descripcion";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@descripcion", genero.Descripcion);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {
                string cadenaComando = "SELECT GeneroId, Descripcion FROM Generos WHERE Descripcion=@descripcion" +
                    " AND GeneroId<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@descripcion", genero.Descripcion);
                comando.Parameters.AddWithValue("@id", genero.GeneroId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
        }
        public Genero GetGeneroPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Genero genero)
        {
            if (genero.GeneroId == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Generos VALUES(@descripcion)";
                    SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@descripcion", genero.Descripcion);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, conexion);
                    genero.GeneroId = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE Generos SET Descripcion=@descripcion WHERE GeneroId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@descripcion", genero.Descripcion);
                    comando.Parameters.AddWithValue("@id", genero.GeneroId);
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
