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
    public class ServicioProvincia : IServicioProvincia
    {
        private IRepositorioProvincias repositorio;
        private ConexionBD conexion;

        public ServicioProvincia()
        {
           
        }
        public List<Provincia> GetProvincia()
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioProvincias(conexion.AbrirConexion());
                var lista = repositorio.GetProvincia();
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
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioProvincias(conexion.AbrirConexion());
                repositorio.Borrar(id);
                conexion.CerrarConexion();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Provincia provincia)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioProvincias(conexion.AbrirConexion());
                var existe = repositorio.Existe(provincia);
                conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Provincia GetProvinciaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Provincia provincia)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioProvincias(conexion.AbrirConexion());
                repositorio.Guardar(provincia);
                conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
