using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using MythoMagic.Clases;

namespace MythoMagic
{
    public partial class Form1 : Form
    {
        private const int fila = 30;
        private const int columna = 30;
        private const int cellSize = 20;

        private Tablero tablero;
        private Juego juego;
        private Fichas fichaSeleccionada;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ClientSize = new Size(columna * cellSize, fila * cellSize);
            InicializarJuego();
        }

        private void InicializarJuego()
        {
            tablero = new Tablero(fila, columna);
            juego = new Juego();

            var j1 = new Jugador { Nombre = "Jugador1" };
            var j2 = new Jugador { Nombre = "Jugador2" };

            var f1 = new Fichas
            {
                Nombre = "Hermes",
                Velocidad = 3,
                CoolDownMax = 2,
                Posicion = new Point(0, 0),
                Dueño = j1
            };

            var f2 = new Fichas
            {
                Nombre = "Ares",
                Velocidad = 2,
                CoolDownMax = 1,
                Posicion = new Point(columna - 1, fila - 1),
                Dueño = j2
            };

            j1.Fichas.Add(f1);
            j2.Fichas.Add(f2);
            juego.Jugadores.Add(j1);
            juego.Jugadores.Add(j2);
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panelLab_Paint(object sender, PaintEventArgs e)
        {

            base.OnPaint(e);
            Graphics g = e.Graphics;

            for (int y = 0; y < fila; y++)
            {
                for (int x = 0; x < columna; x++)
                {
                    Color color;
                    if (x == 0 && y == 0)
                        color = Color.Green; // Entrada
                    else if (x == columna - 1 && y == fila - 1)
                        color = Color.Red;   // Salida
                    else
                        color = tablero[y, x] == 1 ? Color.Purple : Color.White;

                    using (SolidBrush b = new SolidBrush(color))
                    {
                        g.FillRectangle(b, x * cellSize, y * cellSize, cellSize, cellSize);
                    }
                }
            }
        }
    }
}
   

      