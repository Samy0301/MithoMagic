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

    public class AteneaFicha : Fichas
    {
        public override void UsarHabilidad(Tablero tablero)
        {
            tablero.Trampas[Posicion.Y, Posicion.X] = new TrampParalizar();
            base.UsarHabilidad(tablero);
        }
    }

    public class PoseidonFicha : Fichas
    {
        public override void UsarHabilidad(Tablero tablero)
        {
            Velocidad += 2; 
            base.UsarHabilidad(tablero);
        }
    }

    public class HermesFicha : Fichas
    {
        public override void UsarHabilidad(Tablero tablero)
        {
            Velocidad *= 3;
            base.UsarHabilidad(tablero);
        }
    }

    public class AfroditaFicha : Fichas
    {
        public override void UsarHabilidad(Tablero tablero)
        {
            Point frente = new Point(Posicion.X + 1, Posicion.Y);
            if (frente.X < tablero.Columna && tablero.Trampas[frente.Y, frente.X] != null)
            {
                tablero.Trampas[frente.Y, frente.X] = null;
            }
            base.UsarHabilidad(tablero);
        }
    }

    public class AresFicha : Fichas
    {
        public bool InmuneEsteTurno { get; private set; }
        public override void UsarHabilidad(Tablero tablero)
        {
            InmuneEsteTurno = true;
            base.UsarHabilidad(tablero);
        }
        public void ConsumirInmunidad()
        {
            InmuneEsteTurno=false;
        }
    }

    public class ApoloFicha : Fichas
    {
        public bool PuedeAtravesarParedes { get; private set; }
        public override void UsarHabilidad(Tablero tablero)
        {
            PuedeAtravesarParedes = true;
            base.UsarHabilidad(tablero);
        }

        public void DesactivarAtravesar()
        {
            PuedeAtravesarParedes = false;
        }
    }
}  