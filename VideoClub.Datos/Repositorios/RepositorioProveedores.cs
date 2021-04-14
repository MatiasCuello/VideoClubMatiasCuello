using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Datos.Repositorios.Facades;
using VideoClubEntidades.DTOs.Proveedor;
using VideoClubEntidades.Entidades;

namespace VideoClub.Datos.Repositorios
{
    public class RepositorioProveedores : IRepositorioProveedores
    {
        private readonly SqlConnection _sqlConnection;
        public RepositorioProveedores(SqlConnection sqlConnection )
        {
            _sqlConnection = sqlConnection;
        }
     
        public List<ProveedorListDto> GetLista()
        {
            List<ProveedorListDto> lista = new List<ProveedorListDto>();
            try
            {
                string cadenaComando =
                    "SELECT ProveedorId, CUIT, RazonSocial, NombreProvincia, NombreLocalidad FROM Proveedores " +
                    "INNER JOIN Provincias ON Proveedores.ProvinciaId=Provincias.ProvinciaId " +
                    "INNER JOIN Localidades ON Proveedores.LocalidadId=Localidades.LocalidadId";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var proveedorListDto = ConstruirProveedorListDto(reader);
                    lista.Add(proveedorListDto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer los proveedores");
            }
        }

        private ProveedorListDto ConstruirProveedorListDto(SqlDataReader reader)
        {
            return new ProveedorListDto
            {
                ProveedorId = reader.GetInt32(0),
                CUIT = reader.GetString(1),
                RazonSocial = reader.GetString(2),
                Provincia = reader.GetString(3),
                Localidad = reader.GetString(4)
            };
        }
    }
}
