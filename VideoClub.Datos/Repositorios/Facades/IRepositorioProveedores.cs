using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubEntidades.DTOs.Proveedor;

namespace VideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioProveedores
    {
        List<ProveedorListDto> GetLista();
    }
}
