using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubEntidades.DTOs.Localidad;
using VideoClubEntidades.Entidades;

namespace VideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioLocalidades
    {
        List<LocalidadListDto> GetLista(Provincia provincia);
        void Guardar(Localidad localidad);
        bool Existe(Localidad localidad);
        void Borrar(int Id);
        LocalidadEditDto GetLocalidadPorId(int id);
    }
}
