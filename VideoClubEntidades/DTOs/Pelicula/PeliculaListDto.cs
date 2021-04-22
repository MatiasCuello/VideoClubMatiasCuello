using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClubEntidades.DTOs.Pelicula
{
    public class PeliculaListDto
    {
        public int PeliculaId { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public DateTime FechaIncorporacion { get; set; }
        public string Estado { get; set; }
        public double DuracionEnMinutos { get; set; }
        public string Calificacion { get; set; }
        public bool Alquilado { get; set; } = false;
        public bool Activo { get; set; } = true;
        public string Soporte { get; set; }
    }
}
