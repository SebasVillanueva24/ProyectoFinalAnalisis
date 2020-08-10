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
    public partial class ArbolGen : Form
    {
        Individuo hijo;
        Individuo padre;
        Individuo madre;

        public ArbolGen(Individuo pHijo)
        {

            InitializeComponent();


            hijo = pHijo;

           
            padre = hijo.getPadre();

            madre = hijo.getMadre();

            if(padre == null && madre == null)
            {
                button1.Text = "Null";
                button2.Text = "Null";
                button3.Text = hijo.getID().ToString();
            }
            else
            {
                button1.Text = padre.getID().ToString();
                button2.Text = madre.getID().ToString();
                button3.Text = hijo.getID().ToString();
            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            hijo = padre;

            padre = hijo.getPadre();

            madre = hijo.getMadre();

            if (padre == null && madre == null)
            {
                button1.Text = "Null";
                button2.Text = "Null";
                button3.Text = hijo.getID().ToString();
            }
            else
            {
                button1.Text = padre.getID().ToString();
                button2.Text = madre.getID().ToString();
                button3.Text = hijo.getID().ToString();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            hijo = madre;

            padre = hijo.getPadre();

            madre = hijo.getMadre();

            if (padre == null && madre == null)
            {
                button1.Text = "Null";
                button2.Text = "Null";
                button3.Text = hijo.getID().ToString();
            }
            else
            {
                button1.Text = padre.getID().ToString();
                button2.Text = madre.getID().ToString();
                button3.Text = hijo.getID().ToString();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            padre = hijo.getPadre();

            madre = hijo.getMadre();

            if (padre == null && madre == null)
            {
                button1.Text = "Null";
                button2.Text = "Null";
                button3.Text = hijo.getID().ToString();
            }
            else
            {
                button1.Text = padre.getID().ToString();
                button2.Text = madre.getID().ToString();
                button3.Text = hijo.getID().ToString();
            }

        }
    }
}
