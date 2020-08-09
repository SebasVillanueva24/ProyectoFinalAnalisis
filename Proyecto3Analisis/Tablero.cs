using System;
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


        
        public Tablero()
        {
            
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
                        Console.WriteLine(cont2);
                        Console.WriteLine(cont + "cuenta");
                        cont2++;
                        
                    }
                    else 
                    {
                   
                        this.filas.Add(fila);

                        fila = new List<Casilla>();

                        Casilla nueva = new Casilla(tipo, cont);
                        fila.Add(nueva);

                        cont2 = 1;
                    }

                    cont++;
                  

                    
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
            
            for (int i = 0; i < filas.Count; i++)
            {
                for (int j = 0; j < filas.ElementAt(i).Count; j++)
                {
                    filas.ElementAt(i).ElementAt(j).mostrar();
                }
                Console.WriteLine("-------------------------------------");
            }

            Console.WriteLine(filas.Count);
            Console.WriteLine(filas.ElementAt(0).Count);


        }
    }
}
