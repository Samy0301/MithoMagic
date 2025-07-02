using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MythoMagic.Clases;

namespace MythoMagic
{
    public partial class Form_Opciones : Form
    {
       

        public Form_Opciones()
        {
            InitializeComponent();
            this.Load += Form_Opciones_Load;
        }

       
        private void Form_Opciones_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Opciones2 juego = new Form_Opciones2();
            juego.Show();
            this.Hide();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxPlayer_TextChanged(object sender, EventArgs e)
        {
            Conf_Jugador.jugador1.Nombre = textBoxPlayer.Text;
        }
       
        private void buttonAtenea_Click(object sender, EventArgs e)
        {
            Conf_Jugador.jugador1.Fichas.Add(new AteneaFicha
            {
                Nombre = "Atenea",
                Velocidad = 3,
                CoolDownMax = 3,
                Posicion = new Point(0, 0)
            });
        }

        private void buttonHermes_Click(object sender, EventArgs e)
        {
            Conf_Jugador.jugador1.Fichas.Add(new HermesFicha
            {
                Nombre = "Hermes",
                Velocidad = 3,
                CoolDownMax = 4,
                Posicion = new Point(0, 0)
            });
        }

        private void buttonPoseidon_Click(object sender, EventArgs e)
        {
            Conf_Jugador.jugador1.Fichas.Add(new PoseidonFicha
            {
                Nombre = "Poseidon",
                Velocidad = 2,
                CoolDownMax = 4,
                Posicion = new Point(0, 0)
            });
        }
    }
}
