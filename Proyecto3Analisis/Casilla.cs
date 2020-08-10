
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto3Analisis
{
    public class Casilla
    {
        int numCasilla;
        int tipoCasilla;

        public Casilla(int pTipo,int pNum)
        {
            numCasilla = pNum;
            tipoCasilla = pTipo;
        }

        public int getID()
        {
            return numCasilla;
        }
        public int getTipo()
        {
            return tipoCasilla;
        }

        public void mostrar()
        {
            Console.WriteLine("ID: "+numCasilla+" - Tipo: "+tipoCasilla);
        }

    }

   
}
