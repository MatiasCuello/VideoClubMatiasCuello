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
            throw new NotImplementedException();
        }

        public bool Existe(Provincia provincia)
        {
            throw new NotImplementedException();
        }

        public Provincia GetProvinciaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Provincia provincia)
        {
            throw new NotImplementedException();
        }
    }
}
