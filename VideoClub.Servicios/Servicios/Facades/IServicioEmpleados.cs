using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubEntidades.DTOs.Empleado;

namespace VideoClub.Servicios.Servicios.Facades
{
    public interface IServicioEmpleados
    {
        List<EmpleadoListDto> GetLista();
    }
}
