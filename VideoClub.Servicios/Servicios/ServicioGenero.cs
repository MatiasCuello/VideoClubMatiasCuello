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
    public class ServicioGenero : IServicioGenero
    {
        private IRepositorioGeneros repositorio;
        private ConexionBD conexion;
        public ServicioGenero()
        {

        }
        public List<Genero> GetGenero()
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioGeneros(conexion.AbrirConexion());
                var lista = repositorio.GetGenero();
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
                repositorio = new RepositorioGeneros(conexion.AbrirConexion());
                repositorio.Borrar(id);
                conexion.CerrarConexion();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Genero genero)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioGeneros(conexion.AbrirConexion());
                var existe = repositorio.Existe(genero);
                conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    

        public Genero GetGeneroPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Genero genero)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioGeneros(conexion.AbrirConexion());
                repositorio.Guardar(genero);
                conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
