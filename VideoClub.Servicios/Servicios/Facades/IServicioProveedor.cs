using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubEntidades.DTOs.Proveedor;

namespace VideoClub.Servicios.Servicios.Facades
{
    public interface IServicioProveedor
    {
        List<ProveedorListDto> GetLista();
        void Guardar(ProveedorEditDto proveedorEditDto);
        bool Existe(ProveedorEditDto proveedorEditDto);
    }
}
