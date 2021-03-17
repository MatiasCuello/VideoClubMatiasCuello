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
            throw new System.NotImplementedException();
        }

        public bool Existe(Provincia provincia)
        {
            throw new System.NotImplementedException();
        }

        public Provincia GetProvinciaPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Guardar(Provincia provincia)
        {
            throw new System.NotImplementedException();
        }
    }
}
