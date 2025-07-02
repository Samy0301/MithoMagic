using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MythoMagic.Clases
{
    public class Fichas
    {
        public string Nombre { get; set; }
        public int Velocidad { get; set; }
        public int CoolDownMax { get; set; }
        public int CoolDownActual { get; set; } = 0;
        public Point Posicion { get; set; }
        public Jugador Dueño { get; set; }
        public bool PuedeUsarHabilidad => CoolDownActual == 0;

        public virtual void UsarHabilidad(Tablero tablero)
        {
            CoolDownActual = CoolDownMax;
        }

        public void ReducirCoolDown()
        {
            if (CoolDownActual > 0) CoolDownActual--;
        }
    }

}  