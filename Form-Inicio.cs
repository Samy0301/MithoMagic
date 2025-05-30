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
            Form1 juego = new Form1();
            juego.Show();
            this.Hide();
        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
