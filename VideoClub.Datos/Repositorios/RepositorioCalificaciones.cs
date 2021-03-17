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
            throw new NotImplementedException();
        }
        public void Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Calificacion calificacion)
        {
            throw new NotImplementedException();
        }

    }
}
