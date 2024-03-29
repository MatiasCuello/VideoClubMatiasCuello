﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VideoClub.Datos.Repositorios.Facades;
using VideoClubEntidades.DTOs.Localidad;
using VideoClubEntidades.DTOs.Proveedor;
using VideoClubEntidades.Entidades;

namespace VideoClub.Datos.Repositorios
{
    public class RepositorioProveedores : IRepositorioProveedores
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IRepositorioProvincias _repositorioProvincias;
        private readonly IRepositorioLocalidades _repositorioLocalidades;

        public RepositorioProveedores(SqlConnection sqlConnection, IRepositorioProvincias repositorioProvincias, IRepositorioLocalidades repositorioLocalidades)
        {
            _sqlConnection = sqlConnection;
            _repositorioProvincias = repositorioProvincias;
            _repositorioLocalidades = repositorioLocalidades;
        }
        public RepositorioProveedores(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public bool Existe(Proveedor proveedor)
        {
            try
            {
                if (proveedor.ProveedorId == 0)
                {
                    string cadenaComando = "SELECT * FROM Proveedores WHERE RazonSocial=@razonSocial";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@razonSocial", proveedor.RazonSocial);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
                else
                {
                    string cadenaComando =
                        "SELECT * FROM Proveedores WHERE RazonSocial=@razonSocial AND ProveedorId<>@proveedorId";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@razonSocial", proveedor.RazonSocial);
                    comando.Parameters.AddWithValue("@proveedorId", proveedor.ProveedorId);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;

                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ProveedorListDto> GetLista()
        {
            List<ProveedorListDto> lista = new List<ProveedorListDto>();
            try
            {
                string cadenaComando =
                    "SELECT ProveedorId, CUIT, RazonSocial, Direccion, NombreProvincia, NombreLocalidad FROM Proveedores " +
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

        public void Guardar(Proveedor proveedor)
        {
            if (proveedor.ProveedorId == 0)
            {
                try
                {
                string cadenaComando =
                "INSERT INTO Proveedores VALUES( @cuit, @razonSocial, @pcontacto, @direccion, @localidadId, @provinciaId, " +
                "@telFijo, @telMovil, @correo)";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@cuit", proveedor.CUIT);
                comando.Parameters.AddWithValue("@razonSocial", proveedor.RazonSocial);
                comando.Parameters.AddWithValue("@pcontacto", proveedor.PersonaDeContacto);
                comando.Parameters.AddWithValue("@direccion", proveedor.Direccion);
                comando.Parameters.AddWithValue("@localidadId", proveedor.Localidad.LocalidadId);
                comando.Parameters.AddWithValue("@provinciaId", proveedor.Provincia.ProvinciaId);

                if (proveedor.TelefonoFijo != string.Empty)
                {
                    comando.Parameters.AddWithValue("@telFijo", proveedor.TelefonoFijo);

                }
                else
                {
                    comando.Parameters.AddWithValue("@telFijo", DBNull.Value);
                }

                if (proveedor.TelefonoMovil != string.Empty)
                {
                    comando.Parameters.AddWithValue("@telMovil", proveedor.TelefonoMovil);

                }
                else
                {
                    comando.Parameters.AddWithValue("@telMovil", DBNull.Value);
                }

                if (proveedor.CorreoElectronico != string.Empty)
                {
                    comando.Parameters.AddWithValue("@correo", proveedor.CorreoElectronico);

                }
                else
                {
                    comando.Parameters.AddWithValue("@correo", DBNull.Value);
                }

                comando.ExecuteNonQuery();
                cadenaComando = "SELECT @@IDENTITY";
                comando = new SqlCommand(cadenaComando, _sqlConnection);
                proveedor.ProveedorId = (int)(decimal)comando.ExecuteScalar();

            }
                catch (Exception)
            {
                throw new Exception("Error al intentar guardar proveedor");
            }

        }
            else
            {
                try
                {
                    string cadenaComando = "UPDATE Proveedores SET Cuit=@cuit, RazonSocial=@razonSocial," +
                        " PersonaDeContacto=@pcontacto, Direccion=@direccion, LocalidadId=@localidadId," +
                        "ProvinciaId=@provinciaId, TelefonoFijo=@telFijo, TelefonoMovil=@telMovil, CorreoElectronico=@correo" +
                        " WHERE ProveedorId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@cuit", proveedor.CUIT);
                    comando.Parameters.AddWithValue("@razonSocial", proveedor.RazonSocial);
                    comando.Parameters.AddWithValue("@pcontacto", proveedor.PersonaDeContacto);
                    comando.Parameters.AddWithValue("@direccion", proveedor.Direccion);
                    comando.Parameters.AddWithValue("@localidadId", proveedor.Localidad.LocalidadId);
                    comando.Parameters.AddWithValue("@provinciaId", proveedor.Provincia.ProvinciaId);

                    if (proveedor.TelefonoFijo != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@telFijo", proveedor.TelefonoFijo);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@telFijo", DBNull.Value);
                    }

                    if (proveedor.TelefonoMovil != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@telMovil", proveedor.TelefonoMovil);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@telMovil", DBNull.Value);
                    }

                    if (proveedor.CorreoElectronico != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@correo", proveedor.CorreoElectronico);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@correo", DBNull.Value);
                    }
                    comando.Parameters.AddWithValue("@id", proveedor.ProveedorId);
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw new Exception("Error al intentar editar proveedor");
                }

            }
        }

        private ProveedorListDto ConstruirProveedorListDto(SqlDataReader reader)
        {
            return new ProveedorListDto
            {
                ProveedorId = reader.GetInt32(0),
                CUIT = reader.GetString(1),
                RazonSocial = reader.GetString(2),
                Direccion = reader.GetString(3),
                Provincia = reader.GetString(4),
                Localidad = reader.GetString(5)
            };
        }

        public ProveedorEditDto GetProveedorPorId(int proveedorId)
        {
            ProveedorEditDto proveedor = null;
            try
            {
                string cadenaComando =
                    "SELECT ProveedorId, Cuit, RazonSocial, PersonaDeContacto, Direccion, LocalidadId, ProvinciaId," +
                    " TelefonoFijo, TelefonoMovil, CorreoElectronico FROM Proveedores WHERE ProveedorId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", proveedorId);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    proveedor = ConstruirProveedorEditDto(reader);
                }
                reader.Close();
                return proveedor;
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer el proveedor");
            }

        }

        private ProveedorEditDto ConstruirProveedorEditDto(SqlDataReader reader)
        {
            var provincia = _repositorioProvincias.GetProvinciaPorId(reader.GetInt32(5));
            var localidadEditDto = _repositorioLocalidades.GetLocalidadPorId(reader.GetInt32(6));
            return new ProveedorEditDto()
            {
                ProveedorId = reader.GetInt32(0),
                CUIT = reader.GetString(1),
                RazonSocial = reader.GetString(2),
                PersonaDeContacto = reader.GetString(3),
                Direccion = reader.GetString(4),
                Provincia = new Provincia
                {
                    ProvinciaId = provincia.ProvinciaId,
                    NombreProvincia = provincia.NombreProvincia
                },
                Localidad = new LocalidadListDto
                {
                    LocalidadId = localidadEditDto.LocalidadId,
                    NombreLocalidad = localidadEditDto.NombreLocalidad,
                    NombreProvincia = localidadEditDto.Provincia.NombreProvincia
                   
                },
                TelefonoFijo = reader[7] != DBNull.Value ? reader.GetString(7) : string.Empty,
                TelefonoMovil = reader[8] != DBNull.Value ? reader.GetString(8) : string.Empty,
                CorreoElectronico = reader[9] != DBNull.Value ? reader.GetString(9) : string.Empty,
            };
        }
    }
}
