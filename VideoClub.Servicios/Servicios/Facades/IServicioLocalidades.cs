using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubEntidades.DTOs.Localidad;
using VideoClubEntidades.Entidades;

namespace VideoClub.Servicios.Servicios.Facades
{
    public interface IServicioLocalidades
    {
        List<LocalidadListDto> GetLista(Provincia provincia);
        void Guardar(LocalidadEditDto localidadEditDto);
        bool Existe(LocalidadEditDto localidadEditDto);
        void Borrar(int localidadDto);
        LocalidadEditDto GetLocalidadPorId(int id);
    }
}
