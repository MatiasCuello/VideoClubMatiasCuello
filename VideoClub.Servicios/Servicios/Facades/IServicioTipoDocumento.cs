using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubEntidades.Entidades;

namespace VideoClub.Servicios.Servicios.Facades
{
    public interface IServicioTipoDocumento
    {
        List<TipoDocumento> GetTipoDocumento();
    }
}
