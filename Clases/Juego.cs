using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MythoMagic.Clases
{
    public class Juego
    {
        public List<Jugador> Jugadores { get; set; } = new List<Jugador>();
        private int turnoActual = 0;

        public Jugador JugadorActual => Jugadores[turnoActual];

        public void NextTurno()
        {
            foreach (var ficha in JugadorActual.Fichas) ficha.ReducirCoolDown();
            turnoActual = (turnoActual + 1) % Jugadores.Count;
        }
    }
}
