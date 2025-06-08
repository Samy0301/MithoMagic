using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace MythoMagic
{
    public partial class Form1 : Form
    {
        private const int rows = 30;
        private const int cols = 30;
        private const int cellSize = 20;

        private int[,] maze = new int[rows, cols]; // 0 = camino, 1 = pared
        private Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ClientSize = new Size(cols * cellSize, rows * cellSize);
            GenerarLaberinto();
            this.Invalidate(); // Forzar repintado
        }

        private void GenerarLaberinto()
        {
            // Inicializar todo como pared
            for (int y = 0; y < rows; y++)
                for (int x = 0; x < cols; x++)
                    maze[y, x] = 1;

            List<(int x, int y)> frontera = new List<(int x, int y)>();

            void AgregarFrontera(int x, int y)
            {
                if (x > 0 && y > 0 && x < cols - 1 && y < rows - 1 && maze[y, x] == 1)
                {
                    maze[y, x] = 2; // frontera temporal
                    frontera.Add((x, y));
                }
            }

            int startX = 1, startY = 1; // usamos coordenadas impares
            maze[startY, startX] = 0;
            AgregarFrontera(startX + 2, startY);
            AgregarFrontera(startX - 2, startY);
            AgregarFrontera(startX, startY + 2);
            AgregarFrontera(startX, startY - 2);

            while (frontera.Count > 0)
            {
                var idx = rand.Next(frontera.Count);
                var (x, y) = frontera[idx];
                frontera.RemoveAt(idx);

                List<(int dx, int dy)> vecinos = new List<(int dx, int dy)>
                {
                      (-2, 0), (2, 0), (0, -2), (0, 2)
                };

                var vecinosValidos = vecinos
                    .Select(d => (nx: x + d.dx, ny: y + d.dy))
                    .Where(p => p.nx > 0 && p.ny > 0 && p.nx < cols - 1 && p.ny < rows - 1 && maze[p.ny, p.nx] == 0)
                    .ToList();

                if (vecinosValidos.Count > 0)
                {
                    var (nx, ny) = vecinosValidos[rand.Next(vecinosValidos.Count)];

                    maze[y, x] = 0;
                    maze[(y + ny) / 2, (x + nx) / 2] = 0;

                    AgregarFrontera(x + 2, y);
                    AgregarFrontera(x - 2, y);
                    AgregarFrontera(x, y + 2);
                    AgregarFrontera(x, y - 2);
                }
            }

            // Conectar (0,0) com (0,1) o (1,0)
            maze[0, 0] = 0;
            if (maze[1, 0] == 0)
                maze[0, 0] = 0;
            else if (maze[0, 1] == 0)
                maze[0, 0] = 0;
            else
                maze[1, 0] = 0; //Fuera conexion

            //Coectar (rows-1, cols-1) con algun vecino
            maze[rows - 1, cols - 1] = 0;
            if( maze[rows - 2, cols - 1] != 0 && maze[rows - 1, cols - 2] != 0)
                maze[rows - 2, cols - 1] = 0; //Abrir conexion

            //Forzar conexion entre entrada y salida 
            if(!HayCamino(0, 0, rows - 1, cols - 1))
            {
                ConectarEsquinas();
            }
            
        }

        private bool HayCamino(int sx, int sy, int ex, int ey)
        {
            bool[,] visitado = new bool[rows, cols];
            Queue<(int x, int y)> cola = new Queue<(int x, int y)>();
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
                    if (nx >= 0 && ny >= 0 && nx < cols && ny < rows && !visitado[ny, nx] && maze[ny, nx] == 0)
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
            int x = cols - 1;
            int y = rows - 1;

            while (x > 0 || y > 0)
            {
                maze[y, x] = 0;
                if (x > 0 && maze[y, x - 1] == 0) x--;
                else if (y > 0 && maze[y - 1, x] == 0) y--;
                else if (x > 0) x--;
                else y--;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    Color color;
                    if (x == 0 && y == 0)
                        color = Color.Green; // Entrada
                    else if (x == cols - 1 && y == rows - 1)
                        color = Color.Red;   // Salida
                    else
                        color = maze[y, x] == 1 ? Color.Purple : Color.White;

                    using (SolidBrush b = new SolidBrush(color))
                    {
                        g.FillRectangle(b, x * cellSize, y * cellSize, cellSize, cellSize);
                    }
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
   

      