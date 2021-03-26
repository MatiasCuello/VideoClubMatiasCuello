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
    public class ServicioCalificacion:IServicioCalificacion
    {
        private IRepositorioCalificaciones repositorio;
        private ConexionBD conexion;

        public ServicioCalificacion()
        {
            
        }
        public List<Calificacion> GetCalificacion()
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioCalificaciones(conexion.AbrirConexion());
                var lista = repositorio.GetCalificacion();
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
                repositorio = new RepositorioCalificaciones(conexion.AbrirConexion());
                repositorio.Borrar(id);
                conexion.CerrarConexion();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Calificacion calificacion)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioCalificaciones(conexion.AbrirConexion());
                var existe = repositorio.Existe(calificacion);
                conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public Calificacion GetCalificacionPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Calificacion calificacion)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioCalificaciones(conexion.AbrirConexion());
                repositorio.Guardar(calificacion);
                conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
