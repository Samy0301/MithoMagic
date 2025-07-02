using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MythoMagic.Clases
{
    public class Tablero
    {
        public int Fila { get; }
        public int Columna { get; }
        public TipoCasilla[,] Casillas { get; private set; }
        public Trampa[,] Trampas { get; private set; }
        private Random rand = new Random();

        public Tablero(int fila,int columna)
        {
            Fila = fila;
            Columna = columna;
            Casillas = new TipoCasilla[fila, columna];
            Trampas = new Trampa[fila, columna];
            GenerarLaberinto();
        }

        public bool EsValido(Point p) => p.X >= 0 && p.Y >= 0 & p.X < Columna && p.Y < Fila && Casillas[p.Y, p.X] == TipoCasilla.Camino;

        public void ActivarTrampa(Point p,Fichas ficha)
        {
            Trampa t = Trampas[p.Y, p.X];
            if (t != null)
            {
                t.Activar(ficha);
                Trampas[p.Y, p.X] = null;
            }
        }

        private void GenerarLaberinto()
        {
            for(int y = 0; y < Fila; y++)
            {
                for(int x = 0; x < Columna; x++)
                {
                    Casillas[y, x] = TipoCasilla.Pared;
                }
            }

            List<(int x, int y)> frontera = new();
            void AgregarFrontera(int x, int y)
            {
                if (x > 0 && y > 0 && x < Columna - 1 && y < Fila - 1 && Casillas[y, x] == TipoCasilla.Pared)
                {
                    Casillas[y, x] = (TipoCasilla)2;
                    frontera.Add((x, y));
                }
            }

            int startX = 1, startY = 1;
            Casillas[startY, startX] = TipoCasilla.Camino;
            AgregarFrontera(startX + 2, startY);
            AgregarFrontera(startX - 2, startY);
            AgregarFrontera(startX, startY + 2);
            AgregarFrontera(startX, startY - 2);

            while (frontera.Count > 0)
            {
                var idx = rand.Next(frontera.Count);
                var (x, y) = frontera[idx];
                frontera.RemoveAt(idx);

                var vecinos = new List<(int dx, int dy)> 
                {
                      (-2, 0), (2, 0), (0, -2), (0, 2)
                };

                var vecinosValidos = vecinos
                    .Select(d => (x + d.dx, y + d.dy))
                    .Where(p => p.Item1 > 0 && p.Item2 > 0 && p.Item1 < Columna - 1 && p.Item2 < Fila - 1 && Casillas[p.Item2, p.Item1] == TipoCasilla.Camino)
                    .ToList();

                if (vecinosValidos.Count > 0)
                {
                    var (nx, ny) = vecinosValidos[rand.Next(vecinosValidos.Count)];

                    Casillas[y, x] = TipoCasilla.Camino;
                    Casillas[(y + ny) / 2, (x + nx) / 2] = TipoCasilla.Camino;

                    AgregarFrontera(x + 2, y);
                    AgregarFrontera(x - 2, y);
                    AgregarFrontera(x, y + 2);
                    AgregarFrontera(x, y - 2);
                }
            }

            Casillas[0, 0] = TipoCasilla.Camino;
            if (Casillas[1, 0] != TipoCasilla.Camino && Casillas[0, 1] != TipoCasilla.Camino) Casillas[1, 0] = TipoCasilla.Camino];
            if (!HayCamino(0, 0, Fila - 1, Columna - 1)) ConectarEsquinas();
            ColocarTrampas();
        }

        private void ColocarTrampas()
        {
            int cantidad = 10;
            int colocadas = 0;
            while (colocadas < cantidad)
            {
                int x = rand.Next(Columna);
                int y = rand.Next(Fila);

                if (Casillas[y, x] == TipoCasilla.Camino && Trampas[y, x] == null)
                {
                    Trampa trampa = rand.Next(3) switch
                    {
                        0 => new TrampRalentizar(),
                        1 => new TrampRetroceso(),
                        _ => new TrampParalizar(),
                    };
                    Trampas[y, x] = trampa;
                    colocadas++;
                }
            }
        }

        private bool HayCamino(int sx, int sy, int ex, int ey)
        {
            bool[,] visitado = new bool[Fila, Columna];
            Queue<(int x, int y)> cola = new();
            cola.Enqueue((sx, sy));
            visitado[sy, sx] = true;

            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            while (cola.Count > 0)
            {
                var (x, y) = cola.Dequeue();
                if (x == ex && y == ey)
                    return true;

                for (int i = 0; i < 4; i++)
                {
                    int nx = x + dx[i];
                    int ny = y + dy[i];
                    if (nx >= 0 && ny >= 0 && nx < Columna && ny < Fila && !visitado[ny, nx] && Casillas[ny, nx] == TipoCasilla.Camino)
                    {
                        visitado[ny, nx] = true;
                        cola.Enqueue((nx, ny));
                    }
                }
            }

            return false;
        }

        private void ConectarEsquinas()
        {
            int x = Columna - 1;
            int y = Fila - 1;

            while (x > 0 || y > 0)
            {
                Casillas[y, x] = TipoCasilla.Camino;
                if (x > 0 && Casillas[y, x - 1] == TipoCasilla.Camino) x--;
                else if (y > 0 && Casillas[y - 1, x] == TipoCasilla.Camino) y--;
                else if (x > 0) x--;
                else y--;
            }
        }
    }

    public enum TipoCasilla
    {
        Camino,
        Pared
    }
}
