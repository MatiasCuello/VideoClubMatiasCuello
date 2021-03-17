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
            throw new NotImplementedException();
        }

        public bool Existe(Estado estado)
        {
            throw new NotImplementedException();
        }

        public Soporte GetEstadoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Estado estado)
        {
            throw new NotImplementedException();
        }
    }
}

