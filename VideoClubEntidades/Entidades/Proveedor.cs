using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClubEntidades.Entidades
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string PersonaContacto { get; set; }
        public string Direccion { get; set; }
        public Provincia Provincia { get; set; }
        public Localidad Localidad { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }
    }
}
