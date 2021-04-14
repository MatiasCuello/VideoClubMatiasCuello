using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Datos.Repositorios.Facades;
using VideoClubEntidades.DTOs.Empleado;

namespace VideoClub.Datos.Repositorios
{
    public class RepositorioEmpleados : IRepositorioEmpleados
    {
        private readonly SqlConnection _sqlConnection;
        public RepositorioEmpleados(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public List<EmpleadoListDto> GetLista()
        {
            List<EmpleadoListDto> lista = new List<EmpleadoListDto>();
            try
            {
                string cadenaComando = 
                    "SELECT EmpleadoId, Nombre, Apellido, NombreProvincia, NombreLocalidad FROM Empleados" +
                    " INNER JOIN Provincias ON Empleados.ProvinciaId=Provincias.ProvinciaId " +
                    "INNER JOIN Localidades ON Empleados.LocalidadId=Localidades.LocalidadId";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var empleadoListDto = ConstruirEmpleadoListDto(reader);
                    lista.Add(empleadoListDto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer los empleados");
            }
        }

        private EmpleadoListDto ConstruirEmpleadoListDto(SqlDataReader reader)
        {
            return new EmpleadoListDto
            {
                EmpleadoId = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Apellido = reader.GetString(2),
                Provincia = reader.GetString(3),
                Localidad = reader.GetString(4)
            };
        }
    }
}
