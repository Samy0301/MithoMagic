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
    public partial class Form_Inicio : Form
    {
        public Form_Inicio()
        {
            InitializeComponent();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            Form_Opciones juego = new Form_Opciones();
            juego.Show();
            this.Hide();
        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form_Inicio_Load(object sender, EventArgs e)
        {

        }
    }
}
