using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubEntidades.Entidades;

namespace VideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioSoportes
    {
        List<Soporte> GetSoporte();
        void Guardar(Soporte soporte);
        void Borrar(int id);
        bool Existe(Soporte soporte);
        Soporte GetSoportePorId(int id);
    }
}
