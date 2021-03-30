using System;

namespace VideoClubEntidades.Entidades
{
    public class Soporte:ICloneable
    {
        public int SoporteId { get; set; }
        public string Descripcion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
