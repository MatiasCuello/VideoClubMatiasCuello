using System;

namespace VideoClubEntidades.Entidades
{
    public class Provincia: ICloneable
    {
        public int ProvinciaId { get; set; }
        public string NombreProvincia { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
