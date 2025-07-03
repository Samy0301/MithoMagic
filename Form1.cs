using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using MythoMagic.Clases;

namespace MythoMagic
{
    public partial class Form1 : Form
    {
        private const int filas = 30;
        private const int columnas = 30;
        private const int tamañoCelda = 20;

        private Tablero tablero;
        private Juego juego;
        private Fichas fichaSeleccionada;
        private bool poderActivado = false;

        private Button btnUsarPoder;
        private Button btnVolver;
        private ComboBox comboFichas;
        private TextBox txtInfoJugador;
        private ListBox listBoxSalidas;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ClientSize = new Size(columnas * tamañoCelda + 250, filas * tamañoCelda);
            InicializarJuego();
            InicializarUI();
        }

        private void InicializarJuego()
        {
            tablero = new Tablero(filas, columnas);
            juego = new Juego();
            juego.Jugadores.Add(Conf_Jugador.jugador1);
            juego.Jugadores.Add(Conf_Jugador.jugador2);
            fichaSeleccionada = juego.JugadorActual.Fichas[0];
        }

        private void InicializarUI()
        {
            btnUsarPoder = new Button
            {
                Text = "Usar poder",
                Location = new Point(columnas * tamañoCelda + 20, 20),
                Size = new Size(200, 30)
            };
            btnUsarPoder.Click += BtnUsarPoder_Click;
            Controls.Add(btnUsarPoder);

            comboFichas = new ComboBox
            {
                Location = new Point(columnas * tamañoCelda + 20, 60),
                Size = new Size(200, 30),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboFichas.SelectedIndexChanged += ComboFichas_SelectedIndexChanged;
            Controls.Add(comboFichas);

            txtInfoJugador = new TextBox
            {
                Location = new Point(columnas * tamañoCelda + 20, 100),
                Size = new Size(200, 60),
                Multiline = true,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                BackColor = this.BackColor
            };
            Controls.Add(txtInfoJugador);

            listBoxSalidas = new ListBox
            {
                Location = new Point(columnas * tamañoCelda + 20, 170),
                Size = new Size(200, 300)
            };
            Controls.Add(listBoxSalidas);

            ActualizarUI();
        }

        private void ActualizarUI()
        {
            comboFichas.Items.Clear();
            foreach (var ficha in juego.JugadorActual.Fichas)
            {
                if (ficha.Posicion != new Point(columnas - 1, filas - 1))
                    comboFichas.Items.Add(ficha.Nombre);
            }

            if (comboFichas.Items.Count > 0)
            {
                comboFichas.SelectedIndex = 0;
                fichaSeleccionada = juego.JugadorActual.Fichas.Find(f => f.Nombre == comboFichas.SelectedItem.ToString());
            }
            else
            {
                fichaSeleccionada = null;
            }

            txtInfoJugador.Text = $"Turno: {juego.JugadorActual.Nombre}\r\n";
            if (fichaSeleccionada != null)
                txtInfoJugador.Text += $"Ficha: {fichaSeleccionada.Nombre}\r\nCooldown: {fichaSeleccionada.CoolDownActual}";

            poderActivado = false;
            Invalidate();
        }

        private void ComboFichas_SelectedIndexChanged(object sender, EventArgs e)
        {
            fichaSeleccionada = juego.JugadorActual.Fichas.Find(f => f.Nombre == comboFichas.SelectedItem.ToString());
            Invalidate();
        }

        private void BtnUsarPoder_Click(object sender, EventArgs e)
        {
            if (fichaSeleccionada != null && fichaSeleccionada.PuedeUsarHabilidad)
            {
                fichaSeleccionada.UsarHabilidad(tablero);
                poderActivado = true;
                Invalidate();
            }
            else
            {
                MessageBox.Show("El poder aún está en enfriamiento o no hay ficha seleccionada.");
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int y = 0; y < filas; y++)
            {
                for (int x = 0; x < columnas; x++)
                {
                    Color color = Color.White;

                    if (tablero.Casillas[y, x] == TipoCasilla.Pared)
                        color = Color.Purple;
                    else if (tablero.Trampas[y, x] != null)
                        color = Color.Orange;
                    else if (x == 0 && y == 0)
                        color = Color.Green;
                    else if (x == columnas - 1 && y == filas - 1)
                        color = Color.Red;

                    using SolidBrush brush = new(color);
                    g.FillRectangle(brush, x * tamañoCelda, y * tamañoCelda, tamañoCelda, tamañoCelda);
                }
            }

            foreach (var jugador in juego.Jugadores)
            {
                foreach (var ficha in jugador.Fichas)
                {
                    if (ficha.Posicion == new Point(columnas - 1, filas - 1)) continue;
                    Brush brush = ficha == fichaSeleccionada ? Brushes.Yellow : Brushes.Blue;
                    g.FillEllipse(brush, ficha.Posicion.X * tamañoCelda, ficha.Posicion.Y * tamañoCelda, tamañoCelda, tamañoCelda);
                }
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (fichaSeleccionada == null) return;

            int x = e.X / tamañoCelda;
            int y = e.Y / tamañoCelda;
            Point destino = new Point(x, y);

            bool puedeAtravesar = fichaSeleccionada is ApoloFicha ap && ap.PuedeAtravesarParedes;

            if (!tablero.EsValido(destino) && !puedeAtravesar)
                return;

            int distancia = Math.Abs(destino.X - fichaSeleccionada.Posicion.X) + Math.Abs(destino.Y - fichaSeleccionada.Posicion.Y);
            if (distancia <= fichaSeleccionada.Velocidad)
            {
                fichaSeleccionada.Posicion = destino;

                bool esInmune = fichaSeleccionada is AresFicha ares && ares.InmuneEsteTurno;

                if (!esInmune)
                    tablero.ActivarTrampa(destino, fichaSeleccionada);

                if (fichaSeleccionada is AresFicha af) af.ConsumirInmunidad();
                if (fichaSeleccionada is ApoloFicha apf) apf.DesactivarAtravesar();

                if (fichaSeleccionada.Posicion == new Point(columnas - 1, filas - 1))
                    listBoxSalidas.Items.Add($"{juego.JugadorActual.Nombre} - {fichaSeleccionada.Nombre}");

                bool todasSalieron = juego.JugadorActual.Fichas
                    .TrueForAll(f => f.Posicion == new Point(columnas - 1, filas - 1));

                if (todasSalieron)
                {
                    MessageBox.Show($"¡Ganó {juego.JugadorActual.Nombre} con todas sus fichas!", "Victoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                    return;
                }

                juego.NextTurno();
                ActualizarUI();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form_Inicio juego = new Form_Inicio();
            juego.Show();
            this.Hide();
        }
    }
}


    

   

      