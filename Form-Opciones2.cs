using MythoMagic.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MythoMagic
{
    public partial class Form_Opciones2 : Form
    {
        public Form_Opciones2()
        {
            InitializeComponent();
            this.buttonAfrodita.Click += Afrodita_Click;
            this.buttonAres.Click += Ares_Click;
            this.buttonApolo.Click += Apolo_Click;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPlayer_TextChanged(object sender, EventArgs e)
        {
            Conf_Jugador.jugador2.Nombre = textBoxPlayer.Text;
        }

        private void Afrodita_Click(object sender, EventArgs e)
        {
            var select = Conf_Jugador.jugador2.Fichas.Exists(f => f.Nombre == "Afrodita");
            if (select)
            {
                Conf_Jugador.jugador2.Fichas.RemoveAll(f => f.Nombre == "Afrodita");
                buttonAfrodita.FlatStyle = FlatStyle.Standard;
                buttonAfrodita.FlatAppearance.BorderSize = 1;
            }
            else
            {
                Conf_Jugador.jugador2.Fichas.Add(new AfroditaFicha
                {
                    Nombre = "Afrodita",
                    Velocidad = 4,
                    CoolDownMax = 3,
                    Poder= "Remove the trap in front ",
                    Posicion = new Point(0, 0)
                });
                buttonAfrodita.FlatStyle = FlatStyle.Flat;
                buttonAfrodita.FlatAppearance.BorderSize = 2;
                buttonAfrodita.FlatAppearance.BorderColor = Color.LimeGreen;
            }
        }

        private void Ares_Click(object sender, EventArgs e)
        {
            var select = Conf_Jugador.jugador2.Fichas.Exists(f => f.Nombre == "Ares");
            if (select)
            {
                Conf_Jugador.jugador2.Fichas.RemoveAll(f => f.Nombre == "Ares");
                buttonAres.FlatStyle = FlatStyle.Standard;
                buttonAres.FlatAppearance.BorderSize = 1;
            }
            else
            {
                Conf_Jugador.jugador2.Fichas.Add(new AresFicha
                {
                    Nombre = "Ares",
                    Velocidad = 5,
                    CoolDownMax = 4,
                    Poder= "Immune to traps",
                    Posicion = new Point(0, 0)
                });
                buttonAres.FlatStyle = FlatStyle.Flat;
                buttonAres.FlatAppearance.BorderSize = 2;
                buttonAres.FlatAppearance.BorderColor = Color.LimeGreen;
            }
        }

        private void Apolo_Click(object sender, EventArgs e)
        {
            var select = Conf_Jugador.jugador2.Fichas.Exists(f => f.Nombre == "Apolo");
            if (select)
            {
                Conf_Jugador.jugador2.Fichas.RemoveAll(f => f.Nombre == "Apolo");
                buttonApolo.FlatStyle = FlatStyle.Standard;
                buttonApolo.FlatAppearance.BorderSize = 1;
            }
            else
            {
                Conf_Jugador.jugador2.Fichas.Add(new ApoloFicha
                {
                    Nombre = "Apolo",
                    Velocidad = 4,
                    CoolDownMax = 3,
                    Poder= "Go through walls ",
                    Posicion = new Point(0, 0)
                });
                buttonApolo.FlatStyle = FlatStyle.Flat;
                buttonApolo.FlatAppearance.BorderSize = 2;
                buttonApolo.FlatAppearance.BorderColor = Color.LimeGreen;
            }
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPlayer.Text))
            {
                MessageBox.Show("Ingrese el nombre del jugador 2");
                return;
            }
            if (Conf_Jugador.jugador1.Fichas.Count != Conf_Jugador.jugador2.Fichas.Count)
            {
                MessageBox.Show("Ambos jugadors deben tener la misma cantidad de fichas");
                MessageBox.Show($" juador1 {Conf_Jugador.jugador1.Fichas.Count}\n" + $"jugador2 {Conf_Jugador.jugador2.Fichas.Count}\n");
                return;
            }
            Form1 juego = new Form1();
            juego.Show();
            this.Hide();
        }

        private void Form_Opciones2_Load(object sender, EventArgs e)
        {

        }
    }
}
