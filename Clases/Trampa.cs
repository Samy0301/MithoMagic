using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MythoMagic.Clases
{
    public abstract class Trampa
    {
        public abstract void Activar(Fichas ficha);
    }

    public class TrampRalentizar : Trampa
    {
        public override void Activar(Fichas ficha)
        {
            ficha.Velocidad = Math.Max(1, ficha.Velocidad - 1);
        }
    }

    public class TrampRetroceso : Trampa
    {
        public override void Activar(Fichas ficha)
        {
            ficha.Posicion = new Point(0, 0);
        }
    }

    public class TrampParalizar : Trampa
    {
        public override void Activar(Fichas ficha)
        {
            ficha.CoolDownActual = ficha.CoolDownMax;
        }
    }
}
