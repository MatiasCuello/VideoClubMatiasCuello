using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubEntidades.Entidades;

namespace VideoClub.Servicios.Servicios.Facades
{
    public interface IServicioEstado
    {
        List<Estado> GetEstado();
        void Guardar(Estado estado);
        void Borrar(int id);
        bool Existe(Estado estado);
        Estado GetEstadoPorId(int id);
    }
}
