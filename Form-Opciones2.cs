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
            Conf_Jugador.jugador2.Fichas.Add(new AfroditaFicha
            {
                Nombre = "Afrodita",
                Velocidad = 2,
                CoolDownMax = 3,
                Posicion = new Point(29, 29)
            });
        }

        private void Ares_Click(object sender, EventArgs e)
        {
            Conf_Jugador.jugador2.Fichas.Add(new AresFicha
            {
                Nombre = "Ares",
                Velocidad = 3,
                CoolDownMax = 4,
                Posicion = new Point(29, 29)
            });
        }

        private void Apolo_Click(object sender, EventArgs e)
        {
            Conf_Jugador.jugador2.Fichas.Add(new ApoloFicha
            {
                Nombre = "Apolo",
                Velocidad = 2,
                CoolDownMax = 3,
                Posicion = new Point(29, 29)
            });
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            Form1 juego = new Form1();
            juego.Show();
            this.Hide();
        }

        private void Form_Opciones2_Load(object sender, EventArgs e)
        {

        }
    }
}
