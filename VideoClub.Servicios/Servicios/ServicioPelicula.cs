using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Datos;
using VideoClub.Datos.Repositorios;
using VideoClub.Datos.Repositorios.Facades;
using VideoClub.Servicios.Servicios.Facades;
using VideoClubEntidades.DTOs.Pelicula;
using VideoClubEntidades.Entidades;

namespace VideoClub.Servicios.Servicios
{
    public class ServicioPelicula : IServicioPelicula
    {
        private ConexionBD _conexionBD;
        private IRepositorioPeliculas _repositorio;

        public ServicioPelicula(ConexionBD conexionBD, IRepositorioPeliculas repositorio)
        {
            _conexionBD = conexionBD;
            _repositorio = repositorio;

        }
        public ServicioPelicula()
        {

        }

        public List<PeliculaListDto> GetLista()
        {
            try
            {
                _conexionBD = new ConexionBD();
                _repositorio = new RepositorioPeliculas(_conexionBD.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexionBD.CerrarConexion();
                return lista;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
