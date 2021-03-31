using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Datos;
using VideoClub.Datos.Repositorios;
using VideoClub.Datos.Repositorios.Facades;
using VideoClub.Servicios.Servicios.Facades;
using VideoClubEntidades.DTOs.Localidad;
using VideoClubEntidades.Entidades;

namespace VideoClub.Servicios.Servicios
{
    public class ServicioLocalidades : IServicioLocalidades
    {
        private ConexionBD conexionBD;
        private IRepositorioLocalidades repositorio;
     
        public ServicioLocalidades()
        {
           
        }


        public void Guardar(Localidad localidad)
        {
            try
            {
                conexionBD = new ConexionBD();
                repositorio = new RepositorioLocalidades(conexionBD.AbrirConexion());
                repositorio.Guardar(localidad);
                conexionBD.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public bool Existe(Localidad localidad)
        {
            try
            {
                conexionBD = new ConexionBD();
                
                repositorio = new RepositorioLocalidades(conexionBD.AbrirConexion());
                var existe = repositorio.Existe(localidad);
                conexionBD.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(int localidadId)
        {
            try
            {
                conexionBD = new ConexionBD();
                repositorio = new RepositorioLocalidades(conexionBD.AbrirConexion());
                repositorio.Borrar(localidadId);
                conexionBD.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

       

        public List<LocalidadListDto> GetLista()
        {
            try
            {
                conexionBD = new ConexionBD();
                repositorio = new RepositorioLocalidades(conexionBD.AbrirConexion());
                var lista = repositorio.GetLista();
                conexionBD.CerrarConexion();
                return lista;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

       
    }
}
