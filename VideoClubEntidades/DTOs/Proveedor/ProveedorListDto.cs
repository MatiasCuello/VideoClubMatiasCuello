using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClubEntidades.DTOs.Proveedor
{
    public class ProveedorListDto
    {
        public int ProveedorId { get; set; }
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string PersonaContacto { get; set; }
        public string Direccion { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }
    }
}
