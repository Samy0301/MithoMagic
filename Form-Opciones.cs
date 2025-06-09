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
        List<ClassFichas> todaslasfichas;
        List<ClassFichas> fichasJugador1 = new List<ClassFichas>();
        List<ClassFichas> fichasJugador2 = new List<ClassFichas>();
        string jugador1Name;
        string jugador2Name;
        int jugadorActual = 1;
        ToolTip tooltip = new ToolTip();

        public Form_Opciones()
        {
            InitializeComponent();
            this.Load += Form_Opciones_Load;
        }

       
        private void Form_Opciones_Load(object sender, EventArgs e)
        {
            CargarFichas();
            MostrarFichas();
        }

        private void CargarFichas()
        {
            todaslasfichas = new List<ClassFichas>();


        }

        private void MostrarFichas()
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxPlayer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
