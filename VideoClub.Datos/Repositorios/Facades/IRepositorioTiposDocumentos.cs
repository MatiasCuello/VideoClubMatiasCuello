using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubEntidades.Entidades;

namespace VideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioTiposDocumentos
    {
        List<TipoDocumento> GetTipoDocumento();
        
    }
}
