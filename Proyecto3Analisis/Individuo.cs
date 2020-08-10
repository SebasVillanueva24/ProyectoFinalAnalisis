using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto3Analisis
{
    public class Individuo
    {
        int ID = 0;

        int tipoCamara;
        int tipoMotor;
        int tipoBateria;

        int bateriaRestante;

        int calificacion;

        bool objetivo;

        Individuo padre = null;
        Individuo madre = null;

        Stack<Casilla> ruta = new Stack<Casilla>();

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();




        public Individuo(int pID)
        {
            ID = pID;

            tipoCamara = 0;
            tipoMotor = 0;
            tipoBateria = 0;
            calificacion = 0;
            bateriaRestante = 0;

            objetivo = false;
        }

        public int getID()
        {
            return ID;
        }

        public void añadirCasilla(Casilla nueva)
        {
            ruta.Push(nueva);
        }

        public void setPadre(Individuo pPadre)
        {
            padre = pPadre;
        }
        public void setMadre(Individuo pMadre)
        {
            madre = pMadre;
        }

        public Individuo getPadre()
        {
            return padre;
        }
        public Individuo getMadre()
        {
            return madre;
        }



        //Function to get a random number 

        public static int RandomNumber(int min, int max) { lock (syncLock) { return random.Next(min, max); } }



        public void setCalificacion(int resultado)
        {
            calificacion = resultado;
        }

        public Stack<Casilla> getRuta()
        {
            return ruta;
        }


        public void setValores()
        {
            
            int num = RandomNumber(1, 4);

            tipoCamara = num;

            int num2 = RandomNumber(1, 4);

            tipoMotor = num2;

            int num3 = RandomNumber(1, 4);

            tipoBateria = num3;
        }

        public int getTipoCamara()
        {
            return tipoCamara;
        }
        public int getTipoMotor()
        {
            return tipoMotor;
        }
        public int getTipoBateria()
        {
            return tipoBateria;
        }

        public void mostrar()
        {
            Console.WriteLine("ID: "+ID+" [" + tipoCamara + " , " + tipoMotor + " , " + tipoBateria + "]");
        }

        public void mutar()
        {

            int genPorMutar = RandomNumber(1, 4);

            if(genPorMutar == 1)
            {
                int nuevaCamara = RandomNumber(1, 4);

                tipoBateria = nuevaCamara;
            }
            else if (genPorMutar == 2)
            {
                int nuevoMotor = RandomNumber(1, 4);

                tipoMotor = nuevoMotor;
            }
            else if (genPorMutar == 3)
            {
                int nuevaBateria = RandomNumber(1, 4);

                tipoBateria = nuevaBateria;
            }
        }
    }
    
}
