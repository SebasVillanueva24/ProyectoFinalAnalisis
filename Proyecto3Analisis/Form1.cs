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
    public partial class Form1 : Form
    {
        //Probabilidades de la cadena de Markov
        //Motor 1

        int[] normal1 = { 80, 10, 5, 5 };

        //Motor 2

        int[] normal2 = { 50, 40, 5, 5 };
        int[] moderado = { 50, 40, 5, 5 };

        //Motor 3

        int[] normal3 = {45, 30, 20, 5};
        int[] moderado2 = {45, 30, 20, 5};
        int[] dificil = { 45, 30, 20, 5 };

        public Form1()
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
