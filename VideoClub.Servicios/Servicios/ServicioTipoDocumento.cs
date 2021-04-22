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
    public class ServicioTipoDocumento : IServicioTipoDocumento
    {
        private IRepositorioTiposDocumentos repositorio;
        private ConexionBD conexion;
        public ServicioTipoDocumento()
        {

        }
        public List<TipoDocumento> GetTipoDocumento()
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioTiposDocumentos(conexion.AbrirConexion());
                var lista = repositorio.GetTipoDocumento();
                conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
