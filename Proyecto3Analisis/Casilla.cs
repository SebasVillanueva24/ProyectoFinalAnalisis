
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto3Analisis
{
    class Casilla
    {
        int numCasilla;
        int tipoCasilla;
        public int x;
        public int y;

        public Casilla(int pTipo,int pNum,int pX, int pY)
        {
            numCasilla = pNum;
            tipoCasilla = pTipo;
            x = pX;
            y = pY;
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
