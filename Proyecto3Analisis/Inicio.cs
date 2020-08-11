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


            for(int i = 0;i<tablero.getGeneraciones().Count;i++)
            {
                generaciones.Items.Add(i);                
            }
            generaciones.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tablero.mostrar();

            tablero.fitnessPoblacion(generaciones.SelectedIndex);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            tablero.Reproduccion(generaciones.SelectedIndex);

            generaciones.Items.Add(tablero.getGeneraciones().Count-1);
        }

        private void arbol_Click(object sender, EventArgs e)
        {

            int indexGen = generaciones.SelectedIndex;
            int indexRobot = listBox1.SelectedIndex;

            new ArbolGen(tablero.getGeneraciones().ElementAt(indexGen).ElementAt(indexRobot)).Show();


        }

        private void bRuta_Click(object sender, EventArgs e)
        {
            int indexGen = generaciones.SelectedIndex;
            int indexRobot = listBox1.SelectedIndex;

            new Ruta(tablero.getGeneraciones().ElementAt(indexGen).ElementAt(indexRobot)).Show();
        }

        private void generaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            List<Individuo> PoblacionEscogida = tablero.getGeneraciones().ElementAt(generaciones.SelectedIndex);
            for (int i = 0; i < PoblacionEscogida.Count; i++)
            {
                listBox1.Items.Add("ID: " + PoblacionEscogida.ElementAt(i).getID() + " - [" +
                    PoblacionEscogida.ElementAt(i).getTipoCamara() + ", " +
                    PoblacionEscogida.ElementAt(i).getTipoMotor() + ", " +
                    PoblacionEscogida.ElementAt(i).getTipoBateria() + "]");


            }
        }
    }
}
