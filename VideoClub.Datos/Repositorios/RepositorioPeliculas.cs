using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Datos.Repositorios.Facades;
using VideoClubEntidades.DTOs.Pelicula;

namespace VideoClub.Datos.Repositorios
{
    public class RepositorioPeliculas : IRepositorioPeliculas
    {
        private readonly SqlConnection _sqlConnection;
        public RepositorioPeliculas(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public List<PeliculaListDto> GetLista()
        {
            List<PeliculaListDto> lista = new List<PeliculaListDto>();
            try
            {
                string cadenaComando =
                    "SELECT PeliculaId, Titulo, Generos.Descripcion, DurancionEnMinutos, Calificaciones.Descripcion," +
                    "Alquilado, Activa, Soportes.Descripcion FROM Peliculas " +
                    "INNER JOIN Generos ON Peliculas.GeneroId=Generos.GeneroId " +
                    "INNER JOIN Calificaciones ON Peliculas.CalificacionId=Calificaciones.CalificacionId " +
                    "INNER JOIN Soportes ON Peliculas.SoporteId=Soportes.SoporteId";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    PeliculaListDto peliculaListDto = ConstruirPeliculaListDto(reader);
                    lista.Add(peliculaListDto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                    //("Error al intentar leer las peliculas");
            }
        }

        private PeliculaListDto ConstruirPeliculaListDto(SqlDataReader reader)
        {
            return new PeliculaListDto
            {
                PeliculaId = reader.GetInt32(0),
                Titulo = reader.GetString(1),
                Genero = reader.GetString(2),
                DuracionEnMinutos = reader.GetInt32(3),
                Calificacion = reader.GetString(4),
                Alquilado = reader.GetBoolean(5),
                Activa = reader.GetBoolean(6),
                Soporte = reader.GetString(7)
            };
        }
    }
}
