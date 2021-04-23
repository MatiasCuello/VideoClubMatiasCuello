using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Datos;
using VideoClub.Datos.Repositorios;
using VideoClub.Datos.Repositorios.Facades;
using VideoClub.Servicios.Servicios.Facades;
using VideoClubEntidades.DTOs.Proveedor;
using VideoClubEntidades.Entidades;

namespace VideoClub.Servicios.Servicios
{
    public class ServicioProveedor : IServicioProveedor
    {
        private ConexionBD _conexionBD;
        private IRepositorioProveedores _repositorio;
        //private IRepositorioProvincias _repositorioProvincias;
        //private IRepositorioLocalidades _repositorioLocalidades;

        //public ServicioProveedor(ConexionBD conexionBD, IRepositorioProveedores repositorio, IRepositorioProvincias repositorioProvincias, IRepositorioLocalidades repositorioLocalidades)
        //{
        //    _conexionBD = conexionBD;
        //    _repositorio = repositorio;
        //    _repositorioProvincias = repositorioProvincias;
        //    _repositorioLocalidades = repositorioLocalidades;
        //}
        public ServicioProveedor()
        {

        }

        public List<ProveedorListDto> GetLista()
        {
            try
            {
                _conexionBD = new ConexionBD();
                _repositorio = new RepositorioProveedores(_conexionBD.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexionBD.CerrarConexion();
                return lista;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(ProveedorEditDto proveedorEditDto)
        {
            try
            {
                _conexionBD = new ConexionBD();
                _repositorio = new RepositorioProveedores(_conexionBD.AbrirConexion());
                Proveedor proveedor = new Proveedor
                {
                    ProveedorId= proveedorEditDto.ProveedorId,
                    CUIT = proveedorEditDto.CUIT,
                    RazonSocial = proveedorEditDto.RazonSocial,
                    PersonaDeContacto = proveedorEditDto.PersonaDeContacto,
                    Direccion = proveedorEditDto.Direccion,
                    Provincia = new Provincia()
                    {
                        ProvinciaId = proveedorEditDto.Provincia.ProvinciaId,
                        NombreProvincia = proveedorEditDto.Provincia.NombreProvincia
                    },
                    Localidad = new Localidad
                    {
                        LocalidadId = proveedorEditDto.Localidad.LocalidadId,
                        NombreLocalidad = proveedorEditDto.Localidad.NombreLocalidad,
                        Provincia = new Provincia()
                        {
                            ProvinciaId = proveedorEditDto.Provincia.ProvinciaId,
                            NombreProvincia = proveedorEditDto.Provincia.NombreProvincia
                        }
                    },
                    TelefonoFijo = proveedorEditDto.TelefonoFijo,
                    TelefonoMovil = proveedorEditDto.TelefonoMovil,
                    CorreoElectronico = proveedorEditDto.CorreoElectronico
                };
                var existe = _repositorio.Existe(proveedor);
                _conexionBD.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar comprobar si existe el proveedor");
            }
        }

        public void Guardar(ProveedorEditDto proveedorEditDto)
        {
            try
            {
                _conexionBD = new ConexionBD();
                _repositorio = new RepositorioProveedores(_conexionBD.AbrirConexion());
                Proveedor proveedor = new Proveedor
                {
                    ProveedorId = proveedorEditDto.ProveedorId,
                    CUIT = proveedorEditDto.CUIT,
                    RazonSocial = proveedorEditDto.RazonSocial,
                    PersonaDeContacto = proveedorEditDto.PersonaDeContacto,
                    Direccion = proveedorEditDto.Direccion,
                    Provincia = new Provincia()
                    {
                        ProvinciaId = proveedorEditDto.Provincia.ProvinciaId,
                        NombreProvincia = proveedorEditDto.Provincia.NombreProvincia
                    },
                    Localidad = new Localidad
                    {
                        LocalidadId = proveedorEditDto.Localidad.LocalidadId,
                        NombreLocalidad = proveedorEditDto.Localidad.NombreLocalidad,
                        Provincia = new Provincia()
                        {
                            ProvinciaId = proveedorEditDto.Provincia.ProvinciaId,
                            NombreProvincia = proveedorEditDto.Provincia.NombreProvincia
                        }
                    },
                    TelefonoFijo = proveedorEditDto.TelefonoFijo,
                    TelefonoMovil = proveedorEditDto.TelefonoMovil,
                    CorreoElectronico = proveedorEditDto.CorreoElectronico
                };
                _repositorio.Guardar(proveedor);
                proveedorEditDto.ProveedorId = proveedor.ProveedorId;
                _conexionBD.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
