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
            throw new NotImplementedException();
        }

        public bool Existe(Soporte soporte)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
