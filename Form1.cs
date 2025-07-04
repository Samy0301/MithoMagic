using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using MythoMagic.Clases;

namespace MythoMagic
{
    public partial class Form1 : Form
    {
        private const int filas = 29;
        private const int columnas = 29;
        private const int tama�oCelda = 20;

        private Tablero tablero;
        private Juego juego;
        private Fichas fichaSeleccionada;
        private bool poderActivado = false;

        private Button btnUsarPoder;
        private ComboBox comboFichas;
        private TextBox txtInfoJugador;
        private ListBox listBoxSalidas;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ClientSize = new Size(columnas * tama�oCelda + 250, filas * tama�oCelda);
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
                Location = new Point(columnas * tama�oCelda + 20, 20),
                Size = new Size(200, 30)
            };
            btnUsarPoder.Click += BtnUsarPoder_Click;
            Controls.Add(btnUsarPoder);

            comboFichas = new ComboBox
            {
                Location = new Point(columnas * tama�oCelda + 20, 60),
                Size = new Size(200, 30),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboFichas.SelectedIndexChanged += ComboFichas_SelectedIndexChanged;
            Controls.Add(comboFichas);

            txtInfoJugador = new TextBox
            {
                Location = new Point(columnas * tama�oCelda + 20, 100),
                Size = new Size(200, 100),
                Multiline = true,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                BackColor = this.BackColor
            };
            Controls.Add(txtInfoJugador);

            listBoxSalidas = new ListBox
            {
                Location = new Point(columnas * tama�oCelda + 20, 170),
                Size = new Size(200, 300)
            };
            Controls.Add(listBoxSalidas);

            ActualizarUI();
        }

        private void ComboFichas_SelectedIndexChanged(object sender, EventArgs e)
        {
            fichaSeleccionada = juego.JugadorActual.Fichas.Find(f => f.Nombre == comboFichas.SelectedItem.ToString());
            txtInfoJugador.Text = $"Turno: {juego.JugadorActual.Nombre}\r\n";

            if (fichaSeleccionada != null)
            {
                txtInfoJugador.Text += $"Cooldown: {fichaSeleccionada.CoolDownActual}\r\n";
                txtInfoJugador.Text += $"Speed: {fichaSeleccionada.Velocidad}\r\n";
                txtInfoJugador.Text += $"Power: {fichaSeleccionada.Poder}";
            }
            Invalidate();
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
                comboFichas.Refresh();
                string select = comboFichas.Items[0].ToString();
                fichaSeleccionada = juego.JugadorActual.Fichas.Find(f => f.Nombre ==select);
            }
            else
            {
                fichaSeleccionada = null;
            } 

            txtInfoJugador.Text = $"Turno: {juego.JugadorActual.Nombre}\r\n";
            if (fichaSeleccionada != null)
                txtInfoJugador.Text += $"Cooldown: {fichaSeleccionada.CoolDownActual}\r\nSpeed: {fichaSeleccionada.Velocidad}\r\nPower: {fichaSeleccionada.Poder}";

            poderActivado = false;
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
                MessageBox.Show("El poder a�n est� en enfriamiento o no hay ficha seleccionada.");
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // === Dibuja el fondo del tablero ===
            for (int y = 0; y < filas; y++)
            {
                for (int x = 0; x < columnas; x++)
                {
                    Color color = Color.White;

                    if (tablero.Casillas[y, x] == TipoCasilla.Pared)
                        color = Color.Purple;
                    else if (tablero.Trampas[y, x] != null)
                        color = tablero.Trampas[y, x].color;
                    else if (x == 0 && y == 0)
                        color = Color.Green;
                    else if (x == columnas - 1 && y == filas - 1)
                        color = Color.Red;

                    using SolidBrush brush = new(color);
                    g.FillRectangle(brush, x * tama�oCelda, y * tama�oCelda, tama�oCelda, tama�oCelda);
                }
            }

            // === Dibuja las fichas ===
            foreach (var jugador in juego.Jugadores)
            {
                foreach (var ficha in jugador.Fichas)
                {
                    if (ficha.Posicion == new Point(columnas - 1, filas - 1)) continue;

                    Color colorFicha = ficha.ColorFicha;
                    Brush brush = new SolidBrush(colorFicha);

                    if (ficha == fichaSeleccionada)
                    {
                        // Dibujar ficha m�s chica con borde amarillo
                        g.FillEllipse(brush, ficha.Posicion.X * tama�oCelda + 2, ficha.Posicion.Y * tama�oCelda + 2, tama�oCelda - 4, tama�oCelda - 4);
                        g.DrawEllipse(Pens.Yellow, ficha.Posicion.X * tama�oCelda + 1, ficha.Posicion.Y * tama�oCelda + 1, tama�oCelda - 2, tama�oCelda - 2);
                    }
                    else
                    {
                        g.FillEllipse(brush, ficha.Posicion.X * tama�oCelda, ficha.Posicion.Y * tama�oCelda, tama�oCelda, tama�oCelda);
                    }
                }
            }

            // === Dibuja la grilla encima ===
            using Pen pen = new Pen(Color.Gray, 1);
            for (int y = 0; y <= filas; y++)
            {
                int yPos = y * tama�oCelda;
                g.DrawLine(pen, 0, yPos, columnas * tama�oCelda - 1, yPos);
            }

            for (int x = 0; x <= columnas; x++)
            {
                int xPos = x * tama�oCelda;
                g.DrawLine(pen, xPos, 0, xPos, filas * tama�oCelda - 1);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (fichaSeleccionada == null) return;

            int x = e.X / tama�oCelda;
            int y = e.Y / tama�oCelda;
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
                    MessageBox.Show($"�Gan� {juego.JugadorActual.Nombre} con todas sus fichas!", "Victoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                    return;
                }

                juego.NextTurno();
                ActualizarUI();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}


    

   

      