using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClubEntidades.DTOs.Pelicula
{
    public class PeliculaListDto:ICloneable
    {
        public int PeliculaId { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public double DuracionEnMinutos { get; set; }
        public string Calificacion { get; set; }
        public bool Alquilado { get; set; } = false;
        public bool Activa { get; set; } = true;
        public string Soporte { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
