using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubEntidades.DTOs;

namespace VideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioSocios
    {
        List<SocioListDto> GetLista();
    }
}
