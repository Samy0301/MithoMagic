using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MythoMagic.Clases
{
    public class Jugador
    {
        public string Nombre { get; set; }
        public List<Fichas> Fichas { get; set; } = new List<Fichas>();    /* se asignan en los forms opciones */
    }
}
