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
    public class ServicioEstado : IServicioEstado
    {
        private IRepositorioEstados repositorio;
        private ConexionBD conexion;

        public ServicioEstado()
        {

        }
        public List<Estado> GetEstado()
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioEstados(conexion.AbrirConexion());
                var lista = repositorio.GetEstado();
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

        public bool Existe(Estado estado)
        {
            throw new NotImplementedException();
        }

        public Estado GetEstadoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Estado estado)
        {
            throw new NotImplementedException();
        }
    }
}
