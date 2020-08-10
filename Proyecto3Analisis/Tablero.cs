using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto3Analisis
{
    class Tablero
    {
        List<List<Casilla>> filas = new List<List<Casilla>>();

        Random rnd = new Random();

        List<Individuo> Poblacion = new List<Individuo>();

        int cantIndividuos = 1;

        Hashtable Baterias = new Hashtable();

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        //Probabilidades de la cadena de Markov
        //Motor 1

        int[] normal1 = { 80, 10, 5, 5 };

        //Motor 2

        int[] normal2 = { 50, 40, 5, 5 };
        int[] moderado = { 50, 40, 5, 5 };

        //Motor 3

        int[] normal3 = { 45, 30, 20, 5 };
        int[] moderado2 = { 45, 30, 20, 5 };
        int[] dificil = { 45, 30, 20, 5 };

        public Tablero()
        {
            Baterias.Add(1, 180);
            Baterias.Add(2, 260);
            Baterias.Add(3, 380);

            generarPoblacionInicial();

            //fitnessPoblacion();
        }
        public static int RandomNumber(int min, int max) { lock (syncLock) { return random.Next(min, max); } }

        public void generarPoblacionInicial()
        {
         
            for (int i = 1; i<=cantIndividuos;i++)
            {
                Individuo nuevo = new Individuo(i);
                nuevo.setValores();
                Poblacion.Add(nuevo);
            }

            

        }

        public Hashtable costoRutas(int idCasilla,Individuo indv)
        {
            Hashtable costoRutas = new Hashtable();

            int costoArriba = 0;
            int costoDerecha = 0;
            int costoIzquierda = 0;
            int costoAbajo = 0;

            for (int i = 0; i < filas.Count; i++)
            {
                
                for (int j = 0; j < filas.ElementAt(i).Count; j++)
                {
                    if(filas.ElementAt(i).ElementAt(j).getID() == idCasilla)
                    {
         
                        // Ruta de la derecha
                        for(int c = 1; c <= indv.getTipoCamara();c++)
                        {
                            //Pregunta si la casilla de la ruta esta dentro de la matriz
                            if(j+c < 20)
                            {
                                costoDerecha += filas.ElementAt(i).ElementAt(j+c).getTipo();
                                costoDerecha += indv.getTipoCamara();


                            }
                        }
                            
                        //Ruta de la izquierda
                        for (int c = 1; c <= indv.getTipoCamara(); c++)
                        {
                            if (j - c > 0)
                            {
                                costoIzquierda += filas.ElementAt(i).ElementAt(j-c).getTipo();
                                costoIzquierda += indv.getTipoCamara();
                            }
                        }
                        //Ruta de arriba
                        for (int c = 1; c <= indv.getTipoCamara(); c++)
                        {
                            if (i + c < 20)
                            {
                                costoArriba += filas.ElementAt(i+c).ElementAt(j).getTipo();
                                costoArriba += indv.getTipoCamara();
                            }
                        }
                        //Ruta de abajo
                        for (int c = 1; c <= indv.getTipoCamara(); c++)
                        {
                            if (i - c > 0)
                            {
                                costoAbajo += filas.ElementAt(i-c).ElementAt(j).getTipo();
                                costoAbajo += indv.getTipoCamara();
                            }
                        }

                        costoRutas.Add(1, costoAbajo);
                        costoRutas.Add(2, costoArriba);
                        costoRutas.Add(3, costoDerecha);
                        costoRutas.Add(4, costoIzquierda);


                    }
                    break;
                }
                break;
                
            }


            return costoRutas;
        }
        public void sacarRutas(Individuo indv)
        {
            Stack<Casilla> rutaInv = indv.getRuta();

            Casilla casillaActual;

            Console.WriteLine(filas.Count);
            
            int costoMinimo = 10000;
            if (rutaInv.Count == 0)
            {
                casillaActual = filas.ElementAt(0).ElementAt(0);
                
            }
            else
            {
                casillaActual = rutaInv.Peek();
            }

            Hashtable costos = costoRutas(casillaActual.getID(),indv);

            for (int i = 1; i <= 4; i++) 
            {
                Console.WriteLine(i + " " + costos[i].ToString());

                if (Int16.Parse(costos[i].ToString()) < costoMinimo && Int16.Parse(costos[i].ToString()) != 0)
                {
                    costoMinimo = Int16.Parse(costos[i].ToString());
                }
            }
            
            Console.WriteLine("Costo minimo: "+costoMinimo);
        }
        public int fitnessPoblacion()
        {
            int costo = 0;

            
            

            for (int i = 0; i < Poblacion.Count; i++)
            {
                Console.WriteLine("voy a comenzar");
                Individuo indv = Poblacion.ElementAt(i);

                int bateriaTotal = Int16.Parse(Baterias[indv.getTipoBateria()].ToString());

                
                sacarRutas(indv);
                

            }



            return 0;
        }

        public int fitness(Individuo indv)
        {

            return 0;
        }

        public void mostrarPoblacion()
        {
            for (int i = 0; i < cantIndividuos; i++)
            {
                Poblacion.ElementAt(i).mostrar();
            }
        }

        public void leerDatos()
        {
            int cont = 1;
            int cont2 = 1;
            int tipo = 1;
            string line = "";

            List<Casilla> fila = new List<Casilla>();


            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(@"C:\Users\hdavi\OneDrive\Documentos\GitHub\ProyectoFinalAnalisis\Proyecto3Analisis\Datos.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {

                    //write the lie to console window
                    tipo = Int16.Parse(line);

                   
                    if (cont2 < 21)
                    {

                        Casilla nueva = new Casilla(tipo, cont);
                        fila.Add(nueva);

                        cont2++;
                        
                    }
                    else 
                    {
                   
                        this.filas.Add(fila);

                        fila = new List<Casilla>();

                        
                        Casilla nueva = new Casilla(tipo, cont);
                        fila.Add(nueva);

                        cont2 = 2;
                    
                    }

                    if(cont == 400)
                    {
                        this.filas.Add(fila);
                    }
                    else
                    {
                        cont++;
                    }
                   
                  

                    
                    //Read the next line
                    line = sr.ReadLine();
                    
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
           

        public void generarDatos()
        {
            int cont = 1;
            int tipo = 1;
            StreamWriter sw = new StreamWriter(@"C:\Users\hdavi\OneDrive\Documentos\GitHub\ProyectoFinalAnalisis\Proyecto3Analisis\Datos.txt");
            for (int i = 0; i < 20; i++)
            {
                List<Casilla> fila = new List<Casilla>();
                for (int j = 0; j < 20; j++)
                {

                    int num = rnd.Next(0, 101);

                    if (0 < num && num < 40)
                    {
                        tipo = 1;
                    }
                    if (40 < num && num < 70)
                    {
                        tipo = 2;
                    }
                    if (60 < num && num < 90)
                    {
                        tipo = 3;
                    }
                    if (90 < num && num < 100)
                    {
                        tipo = 4;
                    }

                    try
                    {
                        sw.WriteLine(tipo);   
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                    }
                    finally
                    {
                        Console.WriteLine("Executing finally block.");
                    }


                    Casilla nueva = new Casilla(tipo, cont);
                    fila.Add(nueva);
                    cont++;

                }
                this.filas.Add(fila);

            }
            sw.Close();

        }

        public void mostrar()
        {
            for (int i = filas.Count - 1; i >= 0; i--)
            {
                
                Console.Write("[ ");
                for (int j = 0; j < filas.ElementAt(i).Count; j++)
                {
                    if (j == 0)
                    {
                        Console.Write(filas.ElementAt(i).ElementAt(j).getTipo());
                    }
                    else
                    {
                        Console.Write(" , " + filas.ElementAt(i).ElementAt(j).getTipo());
                    }

                }
                Console.WriteLine(" ]");
            }

            Console.WriteLine(filas.Count);
            Console.WriteLine(filas.ElementAt(0).Count);


        }
    }
}
