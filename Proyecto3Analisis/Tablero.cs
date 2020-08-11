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

        List<List<Individuo>> Generaciones = new List<List<Individuo>>();


        int cantIndividuos = 50;

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
            Baterias.Add(1, 400);
            Baterias.Add(2, 800);
            Baterias.Add(3, 1200);

            generarPoblacionInicial();

            Generaciones.Add(Poblacion);


        }
        public static int RandomNumber(int min, int max) { lock (syncLock) { return random.Next(min, max); } }

        public List<List<Individuo>> getGeneraciones()
        {
            return Generaciones;
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

        public List<Individuo> getPoblacion()
        {
            return Poblacion;
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
                   // Console.WriteLine("ID: "+ filas.ElementAt(i).ElementAt(j).getID() + " --   id casilla: " + idCasilla);
                    if (filas.ElementAt(i).ElementAt(j).getID() == idCasilla)
                    {
                        
                        int c = 1;
                        // Ruta de la derecha
                        
                        //Pregunta si la casilla de la ruta esta dentro de la matriz
                        if(j+c < 20)
                        {
                            costoDerecha += filas.ElementAt(i).ElementAt(j+c).getTipo();
                            costoDerecha += indv.getTipoCamara();
                        }
                          
                        //Ruta de la izquierda
                        
                        if (j - c > 0)
                        {
                            costoIzquierda += filas.ElementAt(i).ElementAt(j-c).getTipo();
                            costoIzquierda += indv.getTipoCamara();
                        }
                        
                        //Ruta de arriba
                        
                        if (i + c < 20)
                        {
                            costoArriba += filas.ElementAt(i+c).ElementAt(j).getTipo();
                            costoArriba += indv.getTipoCamara();
                        }
                        
                        //Ruta de abajo
                        
                        if (i - c > 0)
                        {
                            costoAbajo += filas.ElementAt(i-c).ElementAt(j).getTipo();
                            costoAbajo += indv.getTipoCamara();
                        }

                        
                        costoRutas.Add(1, costoAbajo);
                        costoRutas.Add(2, costoArriba);
                        costoRutas.Add(3, costoDerecha);
                        costoRutas.Add(4, costoIzquierda);
                        break;
                    }
                }   
            }
            return costoRutas;
        }
        public int sacarRutas(Individuo indv)
        {
            Stack<Casilla> rutaInv = indv.getRuta();

            Casilla casillaActual;

            int costoMinimo = 10000;

            //List<Casilla> casillasProximas = new List<Casilla>();

            Casilla[] casillasProximas = { null, null, null, null };

            if (rutaInv.Count == 0)
            {
                casillaActual = filas.ElementAt(0).ElementAt(0);  
            }
            else
            {
                casillaActual = rutaInv.Peek();
            }

            Console.Write("Casilla actual: ");
            casillaActual.mostrar();

            Hashtable costos = costoRutas(casillaActual.getID(),indv);

            
            for (int i = 1; i <= 4; i++) 
            {
                Console.WriteLine(i + " " + costos[i].ToString());

                if (Int16.Parse(costos[i].ToString()) < costoMinimo && Int16.Parse(costos[i].ToString()) != 0)
                {
                    costoMinimo = Int16.Parse(costos[i].ToString());
                }
            }
            
            
            Console.WriteLine("\n"+casillaActual.x + " X ");
            Console.WriteLine(casillaActual.y + " Y ");

            if (casillaActual.x - 1 >= 0)
            {
                //Abajo
                casillasProximas[0] = filas.ElementAt(casillaActual.x - 1).ElementAt(casillaActual.y);
            }
            if (casillaActual.x + 1 < 20)
            {
                //Arriba
                casillasProximas[1] = (filas.ElementAt(casillaActual.x + 1).ElementAt(casillaActual.y));
            }
            
            if (casillaActual.y + 1 < 20)
            {
                //Derecha
                casillasProximas[2] = (filas.ElementAt(casillaActual.x).ElementAt(casillaActual.y + 1));
            }
            if (casillaActual.y - 1 >= 0)
            {
                //Izquierda
                casillasProximas[3] = (filas.ElementAt(casillaActual.x).ElementAt(casillaActual.y - 1));
            }


            int costoFinal = 0;

            bool sigo = true;

           

            if (indv.getTipoMotor() == 1)
            {
                while(sigo)
                {
                    int num = RandomNumber(1, 101);

                    if(num <= normal1[0])
                    {
                        for(int i = 0; i < casillasProximas.Length; i++)
                        {
                            if (casillasProximas.ElementAt(i) != null && casillasProximas.ElementAt(i).getTipo() == 1)
                            {
                                if (!indv.getRuta().Contains(casillasProximas.ElementAt(i))) // no la contiene
                                {
                                    if (casillasProximas.ElementAt(i).getID() == 400)
                                    {
                                        indv.setObjetivo(true);
                                    }
                                    indv.añadirCasilla(casillasProximas.ElementAt(i));
                                    costoFinal = Int16.Parse(costos[i + 1].ToString());
                                    sigo = false;
                                    break;
                                }
                            }
                        }
                    }
                    else if(num > normal1[0] && num <= normal1[0]+normal1[1])
                    {
                        for (int i = 0; i < casillasProximas.Length; i++)
                        {
                            if (casillasProximas.ElementAt(i) != null && casillasProximas.ElementAt(i).getTipo() == 2)
                            {
                                if(!indv.getRuta().Contains(casillasProximas.ElementAt(i))) // no la contiene
                                {
                                    if (casillasProximas.ElementAt(i).getID() == 400)
                                    {
                                        indv.setObjetivo(true);
                                    }
                                    indv.añadirCasilla(casillasProximas.ElementAt(i));
                                    costoFinal = Int16.Parse(costos[i + 1].ToString());
                                    sigo = false;
                                    break;
                                }
                                
                            }
                        }
                    }
                    else if (num > normal1[0]+normal1[1] && num <= normal1[0] + normal1[1] + normal1[2])
                    {
                        for (int i = 0; i < casillasProximas.Length; i++)
                        {
                            if (casillasProximas.ElementAt(i) != null && casillasProximas.ElementAt(i).getTipo() == 3)
                            {
                                if (!indv.getRuta().Contains(casillasProximas.ElementAt(i))) // no la contiene
                                {
                                    if (casillasProximas.ElementAt(i).getID() == 400)
                                    {
                                        indv.setObjetivo(true);
                                    }
                                    indv.añadirCasilla(casillasProximas.ElementAt(i));
                                    costoFinal = Int16.Parse(costos[i + 1].ToString());
                                    sigo = false;
                                    break;
                                }
                            }
                        }
                    }
                    else if (num > normal1[0] + normal1[1] + normal1[2] && num <= normal1[0] + normal1[1] + normal1[2] + normal1[3])
                    {
                        for (int i = 0; i < casillasProximas.Length; i++)
                        {
                            if (casillasProximas.ElementAt(i) != null && casillasProximas.ElementAt(i).getTipo() == 4)
                            {
                                if (!indv.getRuta().Contains(casillasProximas.ElementAt(i))) // no la contiene
                                {
                                    if (casillasProximas.ElementAt(i).getID() == 400)
                                    {
                                        indv.setObjetivo(true);
                                    }
                                    indv.añadirCasilla(casillasProximas.ElementAt(i));
                                    costoFinal = Int16.Parse(costos[i + 1].ToString());
                                    sigo = false;
                                    break;
                                }
                            }
                        }
                    }
                    Console.WriteLine("Ciclo 1");
                }
                
            }
                
            else if (indv.getTipoMotor() == 2)
            {
                while (sigo)
                {
                    int num = RandomNumber(1, 101);

                    if (num <= normal2[0])
                    {
                        for (int i = 0; i < casillasProximas.Length; i++)
                        {
                            if (casillasProximas.ElementAt(i) != null && casillasProximas.ElementAt(i).getTipo() == 1)
                            {
                                if (!indv.getRuta().Contains(casillasProximas.ElementAt(i))) // no la contiene
                                {
                                    if (casillasProximas.ElementAt(i).getID() == 400)
                                    {
                                        indv.setObjetivo(true);
                                    }
                                    indv.añadirCasilla(casillasProximas.ElementAt(i));
                                    costoFinal = Int16.Parse(costos[i + 1].ToString());
                                    sigo = false;
                                    break;
                                }
                            }
                        }
                    }
                    else if (num > normal2[0] && num <= normal2[0] + normal2[1])
                    {
                        for (int i = 0; i < casillasProximas.Length; i++)
                        {
                            if (casillasProximas.ElementAt(i) != null && casillasProximas.ElementAt(i).getTipo() == 2)
                            {
                                if (!indv.getRuta().Contains(casillasProximas.ElementAt(i))) // no la contiene
                                {
                                    if (casillasProximas.ElementAt(i).getID() == 400)
                                    {
                                        indv.setObjetivo(true);
                                    }
                                    indv.añadirCasilla(casillasProximas.ElementAt(i));
                                    costoFinal = Int16.Parse(costos[i + 1].ToString());
                                    sigo = false;
                                    break;
                                }
                            }
                        }
                    }
                    else if (num > normal2[0] + normal2[1] && num <= normal2[0] + normal2[1] + normal2[2])
                    {
                        for (int i = 0; i < casillasProximas.Length; i++)
                        {
                            if (casillasProximas.ElementAt(i) != null && casillasProximas.ElementAt(i).getTipo() == 3)
                            {
                                if (!indv.getRuta().Contains(casillasProximas.ElementAt(i))) // no la contiene
                                {
                                    if (casillasProximas.ElementAt(i).getID() == 400)
                                    {
                                        indv.setObjetivo(true);
                                    }
                                    indv.añadirCasilla(casillasProximas.ElementAt(i));
                                    costoFinal = Int16.Parse(costos[i + 1].ToString());
                                    sigo = false;
                                    break;
                                }
                            }
                        }
                    }
                    else if (num > normal2[0] + normal2[1] + normal2[2] && num <= normal2[0] + normal2[1] + normal2[2] + normal2[3])
                    {
                        for (int i = 0; i < casillasProximas.Length; i++)
                        {
                            if (casillasProximas.ElementAt(i) != null && casillasProximas.ElementAt(i).getTipo() == 4)
                            {
                                if (!indv.getRuta().Contains(casillasProximas.ElementAt(i))) // no la contiene
                                {
                                    if (casillasProximas.ElementAt(i).getID() == 400)
                                    {
                                        indv.setObjetivo(true);
                                    }
                                    indv.añadirCasilla(casillasProximas.ElementAt(i));
                                    costoFinal = Int16.Parse(costos[i + 1].ToString());
                                    sigo = false;
                                    break;
                                }
                            }
                        }
                    }
                    Console.WriteLine("Ciclo 2");
                }
            }
            else if (indv.getTipoMotor() == 3)
            {
                while (sigo)
                {
                    int num = RandomNumber(1, 101);

                    if (num <= normal3[0])
                    {
                        for (int i = 0; i < casillasProximas.Length; i++)
                        {
                            if (casillasProximas.ElementAt(i) != null && casillasProximas.ElementAt(i).getTipo() == 1)
                            {
                                if (!indv.getRuta().Contains(casillasProximas.ElementAt(i))) // no la contiene
                                {
                                    if (casillasProximas.ElementAt(i).getID() == 400)
                                    {
                                        indv.setObjetivo(true);
                                    }
                                    indv.añadirCasilla(casillasProximas.ElementAt(i));
                                    costoFinal = Int16.Parse(costos[i + 1].ToString());
                                    sigo = false;
                                    break;
                                }
                            }
                        }
                    }
                    else if (num > normal3[0] && num <= normal3[0] + normal3[1])
                    {
                        for (int i = 0; i < casillasProximas.Length; i++)
                        {
                            if (casillasProximas.ElementAt(i) != null && casillasProximas.ElementAt(i).getTipo() == 2)
                            {
                                if (!indv.getRuta().Contains(casillasProximas.ElementAt(i))) // no la contiene
                                {
                                    if (casillasProximas.ElementAt(i).getID() == 400)
                                    {
                                        indv.setObjetivo(true);
                                    }
                                    indv.añadirCasilla(casillasProximas.ElementAt(i));
                                    costoFinal = Int16.Parse(costos[i + 1].ToString());
                                    sigo = false;
                                    break;
                                }
                            }
                        }
                    }
                    else if (num > normal3[0] + normal3[1] && num <= normal3[0] + normal3[1] + normal3[2])
                    {
                        for (int i = 0; i < casillasProximas.Length; i++)
                        {
                            if (casillasProximas.ElementAt(i) != null && casillasProximas.ElementAt(i).getTipo() == 3)
                            {
                                if (!indv.getRuta().Contains(casillasProximas.ElementAt(i))) // no la contiene
                                {
                                    if (casillasProximas.ElementAt(i).getID() == 400)
                                    {
                                        indv.setObjetivo(true);
                                    }
                                    indv.añadirCasilla(casillasProximas.ElementAt(i));
                                    costoFinal = Int16.Parse(costos[i + 1].ToString());
                                    sigo = false;
                                    break;
                                }
                            }
                        }
                    }
                    else if (num > normal3[0] + normal3[1] + normal3[2] && num <= normal3[0] + normal3[1] + normal3[2] + normal3[3])
                    {
                        for (int i = 0; i < casillasProximas.Length; i++)
                        {
                            if (casillasProximas.ElementAt(i) != null && casillasProximas.ElementAt(i).getTipo() == 4)
                            {
                                if (!indv.getRuta().Contains(casillasProximas.ElementAt(i))) // no la contiene
                                {
                                    if(casillasProximas.ElementAt(i).getID() == 400)
                                    {
                                        indv.setObjetivo(true);
                                    }
                                    indv.añadirCasilla(casillasProximas.ElementAt(i));
                                    costoFinal = Int16.Parse(costos[i + 1].ToString());
                                    sigo = false;
                                    break;

                                }
                            }
                        }
                    }
                    Console.WriteLine("Ciclo 3");
                }
            }

            return costoFinal;
        }

        public void Seleccion(int nGen)
        {
            //
            for (int i = 0; i < Generaciones.ElementAt(nGen).Count; i++)
            {
                Individuo indv = Generaciones.ElementAt(nGen).ElementAt(i);

            }


        }
        public int fitnessPoblacion(int nGen)
        {
            for (int i = 0; i < Generaciones.ElementAt(nGen).Count; i++)
            {
                
                Individuo indv = Generaciones.ElementAt(nGen).ElementAt(i);

                int bateriaTotal = Int16.Parse(Baterias[indv.getTipoBateria()].ToString());

                int costoCasilla = 0; //Debe retornar el costo para restarlo

                while (bateriaTotal>0)
                {
                    if (indv.getRuta().Count>0)  
                    {
                        if(indv.getObjetivo())
                        {
                            Console.WriteLine("Objetivo alcanzado");
                            break;
                        }
                        else
                        {
                            if (indv.getRuta().Peek().getTipo() <= indv.getTipoMotor())
                            {
                                costoCasilla = sacarRutas(indv);

                                bateriaTotal = bateriaTotal - costoCasilla;

                                Console.WriteLine("Bateria Restante: " + bateriaTotal);
                            }
                            else
                            {
                                Console.WriteLine("Motor incapaz");
                                Console.WriteLine("-------------------------------------------------");
                                break;
                            }
                        }
                        
                    }
                    else
                    {
                        costoCasilla = sacarRutas(indv);

                        bateriaTotal = bateriaTotal - costoCasilla;

                        Console.WriteLine("\nBateria Restante: " + bateriaTotal);
                    }
                    
                }

                int calificacion = 0;

                calificacion += indv.getRuta().Count;

                int casillaDificil = 0;

                foreach (Casilla casilla in indv.getRuta())
                {
                    if(casilla.getTipo() == 3)
                    {
                        casillaDificil++;
                    }
                }

                calificacion += casillaDificil;

                indv.setCalificacion(calificacion);

                //Console.WriteLine("ID: "+indv.getID()+"  -  Calificacion: " + calificacion);
            


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
                int i = 0;
                //Continue to read until you reach end of file
                while (line != null)
                {

                    //write the lie to console window
                    tipo = Int16.Parse(line);

                   
                    if (cont2 < 21)
                    {

                        Casilla nueva = new Casilla(tipo, cont,i,cont2-1);
                        fila.Add(nueva);

                        cont2++;
                        
                    }
                    else 
                    {
                   
                        this.filas.Add(fila);

                        fila = new List<Casilla>();

                        
                        i++;

                        //Console.WriteLine(cont);
                        Casilla nueva = new Casilla(tipo, cont,i, 0);
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


                    Casilla nueva = new Casilla(tipo, cont,i,j);
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
