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
        public int VelocidadBase { get; set; }      /* velocidad asignada */
        public int Velocidad { get; set; }          /* velocidad modificada por poderes */
        public int CoolDownMax { get; set; }
        public int CoolDownActual { get; set; } = 0;
        public Point Posicion { get; set; }
        public bool PuedeUsarHabilidad => CoolDownActual == 0;
        public string Poder { get; set; }
        public virtual bool PoderActivo => false;

        public virtual Color ColorFicha => Color.Gray;

        /* son virtual para que cada sub clase implemente su  propiometodo*/
        public virtual void UsarHabilidad(Tablero tablero)
        {
            CoolDownActual = CoolDownMax;
        }

        public void ReducirCoolDown()        /*Se usa en juego.nextTurno*/
        {
            if (CoolDownActual > 0) CoolDownActual--;
        }
    }

    public class AteneaFicha : Fichas
    {
        public override Color ColorFicha => Color.MediumPurple;
        public override void UsarHabilidad(Tablero tablero)
        {
            tablero.Trampas[Posicion.Y, Posicion.X] = new TrampParalizar();
            base.UsarHabilidad(tablero);   /*Se llama al metodo en la base para que actualice el cooldown*/
        }
    }

    public class PoseidonFicha : Fichas
    {
        public override Color ColorFicha => Color.Teal;
        public override void UsarHabilidad(Tablero tablero)
        {
            Velocidad += 3; 
            base.UsarHabilidad(tablero);   /*Se llama al metodo en la base para que actualice el cooldown*/
        }
    }

    public class HermesFicha : Fichas
    {
        public override Color ColorFicha => Color.DodgerBlue;
        public override void UsarHabilidad(Tablero tablero)
        {
            Velocidad *= 2;
            base.UsarHabilidad(tablero);   /*Se llama al metodo en la base para que actualice el cooldown*/
        }
    }

    public class AfroditaFicha : Fichas
    {
        public override Color ColorFicha => Color.HotPink;
        public override void UsarHabilidad(Tablero tablero)
        {
            Point frente = new Point(Posicion.X + 1, Posicion.Y);  /*Point es una cordenada en el tablero X,Y*/
            if (frente.X < tablero.Columna && tablero.Trampas[frente.Y, frente.X] != null)
            {
                tablero.Trampas[frente.Y, frente.X] = null;
            }
            base.UsarHabilidad(tablero);        /*Se llama al metodo en la base para que actualice el cooldown*/
        }
    
    }

    public class AresFicha : Fichas
    {
        public override Color ColorFicha => Color.Crimson;
        public bool InmuneEsteTurno { get; private set; }
        public override void UsarHabilidad(Tablero tablero)
        {
            InmuneEsteTurno = true;
            base.UsarHabilidad(tablero);    /*Se llama al metodo en la base para que actualice el cooldown*/
        }
        public void ConsumirInmunidad()
        {
            InmuneEsteTurno=false;
        }
    }

    public class ApoloFicha : Fichas
    {
        public override Color ColorFicha => Color.Gold;
        public bool PuedeAtravesarParedes { get; private set; }
        public override void UsarHabilidad(Tablero tablero)
        {
            PuedeAtravesarParedes = true;
            base.UsarHabilidad(tablero);        /*Se llama al metodo en la base para que actualice el cooldown*/
        }
        public void DesactivarAtravesar()
        {
            PuedeAtravesarParedes = false;
        }
    }
}  