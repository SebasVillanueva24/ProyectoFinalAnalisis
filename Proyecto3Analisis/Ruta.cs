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
    public partial class Ruta : Form
    {
        Individuo robot;
        public Ruta(Individuo pRobot)
        {
            robot = pRobot;
            InitializeComponent();

            nombre.Text = robot.getID().ToString();


            Stack<Casilla> rutaRobot = robot.getRuta();

            foreach (Casilla casilla in rutaRobot)
            {
               camino.Items.Add("ID: "+ casilla.getID()+ " - Tipo: "+casilla.getTipo());
            }
        }
    }
}
