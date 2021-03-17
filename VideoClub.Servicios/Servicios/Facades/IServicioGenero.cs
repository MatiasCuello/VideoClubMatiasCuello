using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubEntidades.Entidades;

namespace VideoClub.Servicios.Servicios.Facades
{
    public interface IServicioGenero
    {
        List<Genero> GetGenero();
        void Guardar(Genero genero);
        void Borrar(int id);
        bool Existe(Genero genero);
        Genero GetGeneroPorId(int id);
    }
}
