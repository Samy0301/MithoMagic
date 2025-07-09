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
        private const int tamañoCelda = 25;

        private Tablero tablero;
        private Juego juego;
        private Fichas fichaSeleccionada;
        private int movimientosRestantes;

        private Button btnUsarPoder;
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
            movimientosRestantes = fichaSeleccionada?.Velocidad ?? 0;
        }

        private void InicializarUI()
        {
            btnUsarPoder = new Button
            {
                Text = "Use Power",
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
                Size = new Size(200, 100),
                Multiline = true,
                ReadOnly = true,
                BackColor = this.BackColor
            };
            Controls.Add(txtInfoJugador);

            listBoxSalidas = new ListBox
            {
                Location = new Point(columnas * tamañoCelda + 20, 220),
                Size = new Size(200, 300)
            };
            Controls.Add(listBoxSalidas);

            ActualizarUI();
        }

        private void ActualizarUI()
        {
            comboFichas.SelectedIndexChanged -= ComboFichas_SelectedIndexChanged;
            string seleccionAnterior = comboFichas.SelectedItem?.ToString();

            comboFichas.Items.Clear();
            foreach (var ficha in juego.JugadorActual.Fichas)
            {
                if (ficha.Posicion != new Point(columnas - 1, filas - 1))
                    comboFichas.Items.Add(ficha.Nombre);
            }

            if (comboFichas.Items.Count > 0)
            {
                int index = comboFichas.Items.IndexOf(seleccionAnterior);
                comboFichas.SelectedIndex = index >= 0 ? index : 0;
                fichaSeleccionada = juego.JugadorActual.Fichas.Find(f => f.Nombre == comboFichas.SelectedItem.ToString());
                movimientosRestantes = fichaSeleccionada?.Velocidad ?? 0;
            }
            else
            {
                fichaSeleccionada = null;
            }
            comboFichas.SelectedIndexChanged += ComboFichas_SelectedIndexChanged;

            txtInfoJugador.Text = $"Turno: {juego.JugadorActual.Nombre}\r\n";
            if (fichaSeleccionada != null)
                txtInfoJugador.Text += $"Cooldown: {fichaSeleccionada.CoolDownActual}\r\nSpeed: {fichaSeleccionada.Velocidad}\r\nPower: {fichaSeleccionada.Poder}";

            Invalidate();
        }

        private void ComboFichas_SelectedIndexChanged(object sender, EventArgs e)
        {
            fichaSeleccionada = juego.JugadorActual.Fichas.Find(f => f.Nombre == comboFichas.SelectedItem.ToString());
            movimientosRestantes = fichaSeleccionada?.Velocidad ?? 0;
            ActualizarUI();
        }
       
        private void BtnUsarPoder_Click(object sender, EventArgs e)
        {
            if (fichaSeleccionada != null && fichaSeleccionada.PuedeUsarHabilidad)
            {
                fichaSeleccionada.UsarHabilidad(tablero);
                movimientosRestantes = fichaSeleccionada.Velocidad;
                Invalidate();
            }
            else
            {
                MessageBox.Show("El poder aún está en enfriamiento");
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (fichaSeleccionada == null || movimientosRestantes <= 0)
                return base.ProcessCmdKey(ref msg, keyData);

            int dx = 0, dy = 0;
            switch (keyData)
            {
                case Keys.Up:dy = -1; break;
                case Keys.Down: dy = 1; break;
                case Keys.Left: dx = -1; break;
                case Keys.Right: dx = 1; break;
                default: return base.ProcessCmdKey(ref msg, keyData);
            }

            Point nuevaPos = new Point(fichaSeleccionada.Posicion.X + dx, fichaSeleccionada.Posicion.Y + dy);
            bool puedeAtravesar = fichaSeleccionada is ApoloFicha ap && ap.PuedeAtravesarParedes;

            if (!tablero.EsValido(nuevaPos) && !puedeAtravesar)
                return true;

            fichaSeleccionada.Posicion = nuevaPos;

            bool esInmune = fichaSeleccionada is AresFicha ar && ar.InmuneEsteTurno;

            if (!esInmune)
            {
                tablero.ActivarTrampa(nuevaPos, fichaSeleccionada);

                if (fichaSeleccionada.Velocidad <= 0)
                {
                    movimientosRestantes = 0;

                    if (fichaSeleccionada is ApoloFicha apf) apf.DesactivarAtravesar();
                    if (fichaSeleccionada is AresFicha af) af.ConsumirInmunidad();

                    juego.NextTurno();
                    ActualizarUI();
                    Invalidate();
                }
            }
               
            movimientosRestantes--;

            if (fichaSeleccionada.Posicion == new Point(columnas - 1, filas - 1))
                listBoxSalidas.Items.Add($"{juego.JugadorActual.Nombre} - {fichaSeleccionada.Nombre}");

            bool todasSalieron = juego.JugadorActual.Fichas
                .TrueForAll(f => f.Posicion == new Point(columnas - 1, filas - 1));

            if (todasSalieron)
            {
                MessageBox.Show($"Victory for {juego.JugadorActual.Nombre}");
                return true;
            }

            if (movimientosRestantes == 0)
            {
                if (fichaSeleccionada is ApoloFicha apf) apf.DesactivarAtravesar();
                if (fichaSeleccionada is AresFicha af) af.ConsumirInmunidad();

                juego.NextTurno();
                ActualizarUI();
            }

            Invalidate();
            return true;
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
                        color = tablero.Trampas[y, x].color;
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

                    Color colorFicha = ficha.ColorFicha;
                    Brush brush = new SolidBrush(colorFicha);

                    if (ficha == fichaSeleccionada)
                    {
                        
                        g.FillEllipse(brush, ficha.Posicion.X * tamañoCelda + 2, ficha.Posicion.Y * tamañoCelda + 2, tamañoCelda - 4, tamañoCelda - 4);
                        g.DrawEllipse(Pens.Yellow, ficha.Posicion.X * tamañoCelda + 1, ficha.Posicion.Y * tamañoCelda + 1, tamañoCelda - 2, tamañoCelda - 2);
                    }
                    else
                    {
                        g.FillEllipse(brush, ficha.Posicion.X * tamañoCelda, ficha.Posicion.Y * tamañoCelda, tamañoCelda, tamañoCelda);
                    }
                }
            }

            using Pen pen = new Pen(Color.Gray, 1);
            for (int y = 0; y <= filas; y++)
            {
                int yPos = y * tamañoCelda;
                g.DrawLine(pen, 0, yPos, columnas * tamañoCelda - 1, yPos);
            }

            for (int x = 0; x <= columnas; x++)
            {
                int xPos = x * tamañoCelda;
                g.DrawLine(pen, xPos, 0, xPos, filas * tamañoCelda - 1);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}


    

   

      