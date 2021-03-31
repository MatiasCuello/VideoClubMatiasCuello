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
        List<LocalidadListDto> GetLista();
        void Guardar(Localidad localidad);
        bool Existe(Localidad localidad);
        void Borrar(int localidadDto);
        
    }
}
