using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MythoMagic.Clases
{
    internal abstract class ClassFichas
    {
        public string Nombre { get; set; }
        public int Velocidad { get; set; }   
        public Image Imagen { get; set; }
        public int TiempoEnf { get; set; }

        public abstract object Poder();



        public ClassFichas(string nombre, int velocidad, Image imagen, int tiempoEnf )
        {
            Nombre = nombre;
            Velocidad = velocidad;
            Imagen = imagen;
            TiempoEnf = tiempoEnf;
        }   
    }

    public class FichaZeus : ClassFichas
    {

    }

    public class FichaHera : ClassFichas
    {

    }

    public class FichaPoseidon : ClassFichas
    {

    }

    public class FichaDemeter : ClassFichas
    {

    }

    public class FichaAres : ClassFichas
    {

    }

    public class FichaAtenea : ClassFichas
    {

    }

    public class FichaApolo : ClassFichas
    {

    }

    public class FichaArtemisa : ClassFichas
    {

    }

    public class FichaHefesto : ClassFichas
    {

    }

    public class FichaAfrodita : ClassFichas
    {

    }

    public class FichaHermes : ClassFichas
    {

    }

    public class FichaDioniso : ClassFichas
    {

    }

    public class FichaHades : ClassFichas
    {

    }
}
