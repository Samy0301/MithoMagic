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

        public bool EsValido(Point p) =>
         p.X >= 0 && p.Y >= 0 && p.X < Columna && p.Y < Fila &&
         Casillas[p.Y, p.X] == TipoCasilla.Camino;

        public void ActivarTrampa(Point p, Fichas ficha)
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
            int alto = Fila % 2 == 0 ? Fila - 1 : Fila;
            int ancho = Columna % 2 == 0 ? Columna - 1 : Columna;

            Casillas = new TipoCasilla[Fila, Columna];
            Trampas = new Trampa[Fila, Columna];
            bool[,] visitado = new bool[Fila, Columna];

            // Todo es pared al inicio
            for (int y = 0; y < Fila; y++)
                for (int x = 0; x < Columna; x++)
                    Casillas[y, x] = TipoCasilla.Pared;

            // DFS desde (0,0)
            Stack<Point> pila = new Stack<Point>();
            Point inicio = new Point(0, 0);
            pila.Push(inicio);
            visitado[inicio.Y, inicio.X] = true;
            Casillas[inicio.Y, inicio.X] = TipoCasilla.Camino;

            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            while (pila.Count > 0)
            {
                Point actual = pila.Pop();

                var vecinos = new List<Point>();
                foreach (var (ix, iy) in dx.Zip(dy))
                {
                    int nx = actual.X + ix * 2;
                    int ny = actual.Y + iy * 2;

                    if (nx >= 0 && ny >= 0 && nx < ancho && ny < alto && !visitado[ny, nx])
                        vecinos.Add(new Point(nx, ny));
                }

                vecinos = vecinos.OrderBy(v => rand.Next()).ToList();

                foreach (var vecino in vecinos)
                {
                    if (visitado[vecino.Y, vecino.X]) continue;

                    int wallX = (actual.X + vecino.X) / 2;
                    int wallY = (actual.Y + vecino.Y) / 2;

                    Casillas[wallY, wallX] = TipoCasilla.Camino;
                    Casillas[vecino.Y, vecino.X] = TipoCasilla.Camino;

                    visitado[vecino.Y, vecino.X] = true;
                    pila.Push(vecino);
                }
            }

            Casillas[0, 0] = TipoCasilla.Camino;
            Casillas[Fila - 1, Columna - 1] = TipoCasilla.Camino;

            // Garantiza que haya conexión NATURAL, no directa
            if (!HayCamino(0, 0, Columna - 1, Fila - 1))
                ReintentarHastaConectar();

            ColocarTrampas();
            
        }

        private void ReintentarHastaConectar()
        {
            int intentos = 0;
            do
            {
                GenerarLaberinto();
                intentos++;
            } while (!HayCamino(0, 0, Columna - 1, Fila - 1) && intentos < 20);

            if (intentos >= 20)
                MessageBox.Show("No se pudo generar un laberinto conectando entrada y salida después de 20 intentos.");
        }

        private void ColocarTrampas()
        {
            int cantidad = 15, colocadas = 0;
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
                        _ => new TrampParalizar()
                    };
                    Trampas[y, x] = trampa;
                    colocadas++;
                }
            }
        }

        private bool HayCamino(int sx, int sy, int ex, int ey)
        {
            bool[,] visitado = new bool[Fila, Columna];
            Queue<Point> cola = new();
            cola.Enqueue(new Point(sx, sy));
            visitado[sy, sx] = true;

            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            while (cola.Count > 0)
            {
                Point p = cola.Dequeue();
                if (p.X == ex && p.Y == ey) return true;

                for (int i = 0; i < 4; i++)
                {
                    int nx = p.X + dx[i], ny = p.Y + dy[i];
                    if (nx >= 0 && ny >= 0 && nx < Columna && ny < Fila &&
                        !visitado[ny, nx] && Casillas[ny, nx] == TipoCasilla.Camino)
                    {
                        visitado[ny, nx] = true;
                        cola.Enqueue(new Point(nx, ny));
                    }
                }
            }

            return false;
        }

        
    }

    public enum TipoCasilla
    {
        Camino,
        Pared
    }
}
