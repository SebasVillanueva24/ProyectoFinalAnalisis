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
       
        Tablero tablero = new Tablero();


        public Inicio()
        {
            InitializeComponent();

            tablero.leerDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tablero.mostrarPoblacion();

            tablero.fitnessPoblacion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            tablero.mostrar();
        }

        private void arbol_Click(object sender, EventArgs e)
        {
            List<Individuo> pruebas = new List<Individuo>();

            for (int i = 1; i <= 3; i++)
            {
                Individuo nuevo = new Individuo(i);
                nuevo.setValores();
                pruebas.Add(nuevo);
            }

            pruebas.ElementAt(2).setPadre(pruebas.ElementAt(0));
            pruebas.ElementAt(2).setMadre(pruebas.ElementAt(1));

            new ArbolGen(pruebas.ElementAt(2)).Show();


        }

        private void bRuta_Click(object sender, EventArgs e)
        {
           
            Individuo nuevo = new Individuo(0);


            for (int i = 1; i < 6; i++)
            {
                Casilla nueva = new Casilla(1, i);
                nuevo.añadirCasilla(nueva);
            }

            
            new Ruta(nuevo).Show();
        }
    }
}
