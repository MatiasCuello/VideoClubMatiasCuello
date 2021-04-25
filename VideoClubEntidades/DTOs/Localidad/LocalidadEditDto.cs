using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubEntidades.Entidades;

namespace VideoClubEntidades.DTOs.Localidad
{
    public class LocalidadEditDto
    {
        public int LocalidadId { get; set; }
        public string NombreLocalidad { get; set; }
        public Provincia Provincia { get; set; }
    }
}
