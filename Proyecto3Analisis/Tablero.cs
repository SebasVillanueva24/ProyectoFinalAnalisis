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

        int cantIndividuos = 100;

        Hashtable Baterias = new Hashtable();

  




        public Tablero()
        {
            Baterias.Add(1, 100);
            Baterias.Add(2, 200);
            Baterias.Add(3, 300);

            generarPoblacionInicial();

            fitnessPoblacion();


            

        }

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

            //costoRutas.Add("arriba", costo);

            //costoRutas["arriba"];
            int costo = 0;

            for (int i = 0; i < filas.Count; i++)
            {
                
                for (int j = 0; j < filas.ElementAt(i).Count; j++)
                {
                    if(filas.ElementAt(i).ElementAt(j).getID() == idCasilla)
                    {
                        for(int v = 1;v<=indv.getTipoCamara();v++)
                        {
                            // validacion del motor 

                            costo += filas.ElementAt(i).ElementAt(j).getTipo() * indv.getTipoMotor();

                            costo += indv.getTipoCamara() * indv.getTipoCamara();

                        }

                    }
                    

                }
                
            }


            return costoRutas;
        }
        public void sacarRutas(Individuo indv)
        {
            Stack<Casilla> rutaInv = indv.getRuta();

            Casilla casillaActual;

            if (rutaInv.Count == 0)
            {
                casillaActual = filas.ElementAt(0).ElementAt(0);
            }
            else
            {
                casillaActual = rutaInv.Peek();
            }

            costoRutas(casillaActual.getID(),indv);

            
            
        }
        public int fitnessPoblacion()
        {
            int costo = 0;

            Console.WriteLine(Baterias[1]);
            
            for (int i = 1; i < Poblacion.Count; i++)
            {

                Individuo indv = Poblacion.ElementAt(i);

                int bateriaTotal = Int16.Parse(Baterias[indv.getTipoBateria()].ToString());

                int vision = indv.getTipoCamara();
                
                

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
