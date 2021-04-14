using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubEntidades.Entidades;

namespace VideoClubEntidades.DTOs
{
    public class SocioListDto
    {
        public int SocioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public bool Sancionado { get; set; } = false;
        public bool Activo { get; set; } = true;
    }
}
