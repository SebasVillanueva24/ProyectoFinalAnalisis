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

            for(int i = 0;i<tablero.getGeneraciones().Count;i++)
            {
                generaciones.Items.Add(i);

                
            }

            generaciones.SelectedIndex = 0;

            List<Individuo> PoblacionEscogida = tablero.getGeneraciones().ElementAt(0);
            for (int i = 0; i < PoblacionEscogida.Count; i++)
            {
                listBox1.Items.Add("ID: "+ PoblacionEscogida.ElementAt(i).getID() + " - [" +
                    PoblacionEscogida.ElementAt(i).getTipoCamara() + ", " +
                    PoblacionEscogida.ElementAt(i).getTipoMotor() + ", " +
                    PoblacionEscogida.ElementAt(i).getTipoBateria() + "]");


            }
            



        }

        private void button1_Click(object sender, EventArgs e)
        {
            //tablero.mostrarPoblacion();

            tablero.fitnessPoblacion(generaciones.SelectedIndex);
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
            int indexGen = generaciones.SelectedIndex;
            int indexRobot = listBox1.SelectedIndex;

            new Ruta(tablero.getGeneraciones().ElementAt(indexGen).ElementAt(indexRobot)).Show();
        }

        private void generaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
