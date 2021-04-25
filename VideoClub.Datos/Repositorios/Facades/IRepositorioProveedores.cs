using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubEntidades.DTOs.Proveedor;
using VideoClubEntidades.Entidades;

namespace VideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioProveedores
    {
        List<ProveedorListDto> GetLista();
        bool Existe(Proveedor proveedor);
        void Guardar(Proveedor proveedor);
        ProveedorEditDto GetProveedorPorId(int proveedorId);
    }
}
