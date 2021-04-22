using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Datos;
using VideoClub.Datos.Repositorios;
using VideoClub.Datos.Repositorios.Facades;
using VideoClub.Servicios.Servicios.Facades;
using VideoClubEntidades.DTOs.Empleado;
using VideoClubEntidades.Entidades;

namespace VideoClub.Servicios.Servicios
{
    public class ServicioEmpleado : IServicioEmpleados
    {
        private ConexionBD _conexionBD;
        private IRepositorioEmpleados _repositorio;

        public ServicioEmpleado()
        {

        }
        public List<EmpleadoListDto> GetLista()
        {
            try
            {
                _conexionBD = new ConexionBD();
                _repositorio = new RepositorioEmpleados(_conexionBD.AbrirConexion());
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
