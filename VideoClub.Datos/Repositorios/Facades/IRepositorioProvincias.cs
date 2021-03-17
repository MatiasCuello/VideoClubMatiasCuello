using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubEntidades.Entidades;

namespace VideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioProvincias
    {
        List<Provincia> GetProvincia();
        void Guardar(Provincia provincia);
        void Borrar(int id);
        bool Existe(Provincia provincia);
        Provincia GetProvinciaPorId(int id);
    }
}
