using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubEntidades.DTOs.Empleado;

namespace VideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioEmpleados
    {
        List<EmpleadoListDto> GetLista();

    }
}
