using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClubEntidades.DTOs.Empleado
{
    public class EmpleadoListDto
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }
    }
}
