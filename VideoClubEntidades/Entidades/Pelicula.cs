using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClubEntidades.Entidades
{
    public class Pelicula
    {
        public int PeliculaId { get; set; }
        public string Titulo { get; set; }
        public Genero Genero { get; set; }
        public DateTime FechaIncorporacion { get; set; }
        public Estado Estado { get; set; }
        public double DuracionEnMinutos { get; set; }
        public Calificacion Calificacion { get; set; }
        public bool Alquilado { get; set; } = false;
        public bool Activa { get; set; } = true;
        public string Observaciones { get; set; }
        public Soporte Soporte { get; set; }

    }
}
