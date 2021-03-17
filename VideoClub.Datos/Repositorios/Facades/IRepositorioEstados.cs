using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubEntidades.Entidades;

namespace VideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioEstados
    {
        List<Estado> GetEstado();
        void Guardar(Estado estado);
        void Borrar(int id);
        bool Existe(Estado estado);
        Soporte GetEstadoPorId(int id);
    }
}
