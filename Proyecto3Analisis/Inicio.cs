using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto3Analisis
{
    public partial class Inicio : Form
    {
        // aca 
        string a;


        public Inicio()
        {
            InitializeComponent();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Individuo prueba = new Individuo();

            prueba.setValores();
            prueba.mostrar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tablero tablero = new Tablero();

            tablero.leerDatos();

            tablero.mostrar();
        }
    }
}
