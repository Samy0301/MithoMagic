using System.Runtime.CompilerServices;

namespace MythoMagic
{
    public partial class Form1 : Form
    {

        private int rows = 21;
        private int cols = 21;
        private int cellSize = 20;
        private int[,] maze;
        private Random rand = new Random();


        public Form1()
        {
            InitializeComponent();
            this.Width = cols * cellSize + 16;
            this.Height = rows * cellSize + 39;
            this.DoubleBuffered = true;

            GenerarLaberinto();
        }


        private void GenerarLaberinto()
        {
            maze = new int[rows, cols];

            // Inicializa con paredes
            for (int y = 0; y < rows; y++)
            for (int x = 0; x < cols; x++)
            maze[y, x] = 1;

            // Algoritmo de backtracking para generar caminos
            CrearCamino(1, 1);

            Invalidate(); // Redibuja
        }

            private void CrearCamino(int y, int x)
            {
                maze[y, x] = 0;

                var dirs = new (int dy, int dx)[] { (0, 2), (0, -2), (2, 0), (-2, 0) };
                Shuffle(dirs);

                foreach (var (dy, dx) in dirs)
                {
                    int ny = y + dy;
                    int nx = x + dx;

                    if (ny > 0 && ny < rows - 1 && nx > 0 && nx < cols - 1 && maze[ny, nx] == 1)
                    {
                        maze[y + dy / 2, x + dx / 2] = 0;
                        CrearCamino(ny, nx);
                    }
                }
            }

            private void Shuffle((int, int)[] array)
            {
                for (int i = array.Length - 1; i > 0; i--)
                {
                    int j = rand.Next(i + 1);
                    (array[i], array[j]) = (array[j], array[i]);
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
                        Brush b = maze[y, x] == 1 ? Brushes.Purple : Brushes.Black;
                        g.FillRectangle(b, x * cellSize, y * cellSize, cellSize, cellSize);
                    }
                }
            }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
   

      