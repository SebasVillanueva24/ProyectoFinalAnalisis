﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto3Analisis
{
    class Individuo
    {
        int tipoCamara;
        int tipoMotor;
        int tipoBateria;

        int bateriaRestante;

        int calificacion;

        Individuo padre = null;
        Individuo madre = null;

        Stack ruta = new Stack();
        Random rnd = new Random();

        bool objetivo;

        public Individuo()
        {
            tipoCamara = 0;
            tipoMotor = 0;
            tipoBateria = 0;
            calificacion = 0;
            bateriaRestante = 0;

            objetivo = false;
        }

        public void setValores()
        {
            int num = rnd.Next(1, 4);

            tipoCamara = num;

            num = rnd.Next(1, 4);

            tipoMotor = num;

            num = rnd.Next(1, 4);

            tipoBateria = num;
        }

        public void mostrar()
        {
            Console.WriteLine("[" + tipoCamara + " , " + tipoMotor + " , " + tipoBateria + "]");
        }

        public void mutar()
        {
            int genPorMutar = rnd.Next(1, 4);

            if(genPorMutar == 1)
            {
                int nuevaCamara = rnd.Next(1, 4);

                tipoBateria = nuevaCamara;
            }
            else if (genPorMutar == 2)
            {
                int nuevoMotor = rnd.Next(1, 4);

                tipoMotor = nuevoMotor;
            }
            else if (genPorMutar == 3)
            {
                int nuevaBateria = rnd.Next(1, 4);

                tipoBateria = nuevaBateria;
            }
        }
    }
    
}
