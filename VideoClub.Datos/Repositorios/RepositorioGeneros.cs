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
            throw new NotImplementedException();
        }

        public bool Existe(Genero genero)
        {
            throw new NotImplementedException();
        }

        public Genero GetGeneroPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Genero genero)
        {
            throw new NotImplementedException();
        }
    }
}
