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
        private IRepositorioProvincias _repositorioProvincias;
     
        public ServicioLocalidades()
        {
           
        }


        public void Guardar(LocalidadEditDto localidadDto)
        {
            try
            {
                conexionBD = new ConexionBD();
                repositorio = new RepositorioLocalidades(conexionBD.AbrirConexion());
                _repositorioProvincias = new RepositorioProvincias(conexionBD.AbrirConexion());
                var localidad = new Localidad
                {
                    LocalidadId = localidadDto.LocalidadId,
                    NombreLocalidad = localidadDto.NombreLocalidad,
                    Provincia = _repositorioProvincias.GetProvinciaPorId(localidadDto.ProvinciaId)

                };
                repositorio.Guardar(localidad);
                conexionBD.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public bool Existe(LocalidadEditDto localidadDto)
        {
            try
            {
                conexionBD = new ConexionBD();
                repositorio = new RepositorioLocalidades(conexionBD.AbrirConexion());
                _repositorioProvincias=new RepositorioProvincias(conexionBD.AbrirConexion());
                var localidad = new Localidad
                {
                    LocalidadId = localidadDto.LocalidadId,
                    NombreLocalidad = localidadDto.NombreLocalidad,
                    Provincia = _repositorioProvincias.GetProvinciaPorId(localidadDto.ProvinciaId)

                };
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

        public LocalidadEditDto GetLocalidadPorId(int id)
        {
            try
            {
                conexionBD = new ConexionBD();
                _repositorioProvincias = new RepositorioProvincias(conexionBD.AbrirConexion());
                repositorio = new RepositorioLocalidades(conexionBD.AbrirConexion(),_repositorioProvincias);
                var localidad = repositorio.GetLocalidadporId(id);
                conexionBD.CerrarConexion();
                return localidad;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
