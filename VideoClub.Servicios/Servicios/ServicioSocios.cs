using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Datos;
using VideoClub.Datos.Repositorios;
using VideoClub.Datos.Repositorios.Facades;
using VideoClub.Servicios.Servicios.Facades;
using VideoClubEntidades.DTOs;

namespace VideoClub.Servicios.Servicios
{
    public class ServicioSocios : IServicioSocios
    {
        private ConexionBD _conexionBD;
        private IRepositorioSocios _repositorio;
        public ServicioSocios()
        {
                
        }
        
        public List<SocioListDto> GetLista()
        {
            try
            {
                _conexionBD = new ConexionBD();
                _repositorio = new RepositorioSocios(_conexionBD.AbrirConexion());
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
