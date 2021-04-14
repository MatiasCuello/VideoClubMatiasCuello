using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubEntidades.DTOs;

namespace VideoClub.Servicios.Servicios.Facades
{
    public interface IServicioSocios
    {
        List<SocioListDto> GetLista();
    }
}
