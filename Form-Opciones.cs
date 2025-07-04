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
            this.buttonAtenea.MouseClick += buttonAtenea_Click;
            this.buttonPoseidon.MouseClick += buttonPoseidon_Click;
            this.buttonHermes.MouseClick += buttonHermes_Click;
        }

       
        private void Form_Opciones_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPlayer.Text))
            {
                MessageBox.Show("Ingrese el nombre del jugador 1");
                return;
            }
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
       
        private void buttonAtenea_Click(object sender, MouseEventArgs e)
        {
            var select = Conf_Jugador.jugador1.Fichas.Exists(f => f.Nombre == "Atenea");
            if (select)
            {
                Conf_Jugador.jugador1.Fichas.RemoveAll(f => f.Nombre == "Atenea");
                buttonAtenea.FlatStyle = FlatStyle.Standard;
                buttonAtenea.FlatAppearance.BorderSize = 1;
            }
            else
            {
                Conf_Jugador.jugador1.Fichas.Add(new AteneaFicha
                {
                    Nombre = "Atenea",
                    Velocidad = 5,
                    CoolDownMax = 4,
                    Poder = "Turn box into a paralyzing trap",
                    Posicion = new Point(0, 0)
                });
                buttonAtenea.FlatStyle = FlatStyle.Flat;
                buttonAtenea.FlatAppearance.BorderSize = 2;
                buttonAtenea.FlatAppearance.BorderColor = Color.LimeGreen;
            }
        }

        private void buttonHermes_Click(object sender, MouseEventArgs e)
        {
            var select = Conf_Jugador.jugador1.Fichas.Exists(f => f.Nombre == "Hermes");
            if (select)
            {
                Conf_Jugador.jugador1.Fichas.RemoveAll(f => f.Nombre == "Hermes");
                buttonHermes.FlatStyle = FlatStyle.Standard;
                buttonHermes.FlatAppearance.BorderSize = 1;
            }
            else
            {
                Conf_Jugador.jugador1.Fichas.Add(new HermesFicha
                {
                    Nombre = "Hermes",
                    Velocidad = 5,
                    CoolDownMax = 4,
                    Poder = "Multiply the speed by 2",
                    Posicion = new Point(0, 0)
                });
                buttonHermes.FlatStyle = FlatStyle.Flat;
                buttonHermes.FlatAppearance.BorderSize = 2;
                buttonHermes.FlatAppearance.BorderColor = Color.LimeGreen;
            }
        }

        private void buttonPoseidon_Click(object sender, MouseEventArgs e)
        {
            var select = Conf_Jugador.jugador1.Fichas.Exists(f => f.Nombre == "Poseidon");
            if (select)
            {
                Conf_Jugador.jugador1.Fichas.RemoveAll(f => f.Nombre == "Poseidon");
                buttonPoseidon.FlatStyle = FlatStyle.Standard;
                buttonPoseidon.FlatAppearance.BorderSize = 1;
            }
            else
            {
                Conf_Jugador.jugador1.Fichas.Add(new PoseidonFicha
                {
                    Nombre = "Poseidon",
                    Velocidad = 4,
                    CoolDownMax = 4,
                    Poder= "Add 3 to the speed ",
                    Posicion = new Point(0, 0)
                });
                buttonPoseidon.FlatStyle = FlatStyle.Flat;
                buttonPoseidon.FlatAppearance.BorderSize = 2;
                buttonPoseidon.FlatAppearance.BorderColor = Color.LimeGreen;
            }
        }
    }
}
