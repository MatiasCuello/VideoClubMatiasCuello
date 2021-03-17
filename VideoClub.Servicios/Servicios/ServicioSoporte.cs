using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Datos;
using VideoClub.Datos.Repositorios;
using VideoClub.Datos.Repositorios.Facades;
using VideoClub.Servicios.Servicios.Facades;
using VideoClubEntidades.Entidades;

namespace VideoClub.Servicios.Servicios
{
    public class ServicioSoporte : IServicioSoporte
    {
        private IRepositorioSoportes repositorio;
        private ConexionBD conexion;

        public ServicioSoporte()
        {

        }
        public List<Soporte> GetSoporte()
        {

            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioSoportes(conexion.AbrirConexion());
                var lista = repositorio.GetSoporte();
                conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public void Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Soporte soporte)
        {
            throw new NotImplementedException();
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
