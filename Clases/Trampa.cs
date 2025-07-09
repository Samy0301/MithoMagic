using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MythoMagic.Clases
{
    public abstract class Trampa
    {
        public virtual Color color => Color.Gray;
        public abstract void Activar(Fichas ficha);
    }

    public class TrampRalentizar : Trampa
    {
        public override void Activar(Fichas ficha)
        {
            ficha.Velocidad = 0;
        }

        public override Color color => Color.BlueViolet;
    }

    public class TrampRetroceso : Trampa
    {
        public override void Activar(Fichas ficha)
        {
            ficha.Posicion = new Point(0, 0);
        }

        public override Color color => Color.DarkRed;
    }

    public class TrampParalizar : Trampa
    {
        public override void Activar(Fichas ficha)
        {
            ficha.CoolDownActual = ficha.CoolDownMax;
        }

        public override Color color => Color.DarkSlateBlue;
    }
}
