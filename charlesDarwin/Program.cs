using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charlesDarwin
{
    class Program
    {
        static Random rand = new Random(DateTime.Now.Millisecond);
        static Random cambio = new Random(DateTime.Now.Second);
        static void Main(string[] args)
        {
            List<combinacion> combinaciones = new List<combinacion>();
            for(int i=0;i<10000;i++)
            {
                combinaciones.Add(new combinacion());
            }
            
            bool continuar=true;
            int mayorEvaluacion = 0, posicionMayorEvaluacion=0;
            int mayorEvaluacion2 = 0, posicionMayorEvaluacion2 = 0;

            while(continuar)
            {
                for (int i = 0; i < combinaciones.Count; i++)
                {
                    if (rand.Next(5) == 1)
                    {
                        combinaciones[i].cadena = combinaciones[posicionMayorEvaluacion].generarDescendencia(combinaciones[posicionMayorEvaluacion2].cadena);
                    }
                }

                mayorEvaluacion = 0;
                posicionMayorEvaluacion = 0;
                for(int i=0;i<combinaciones.Count;i++)
                {
                    //Console.WriteLine(combinaciones[i].cadena + "\tEvaluación: " + combinaciones[i].evaluar());
                    if(combinaciones[i].evaluar()>mayorEvaluacion)
                    {
                        mayorEvaluacion2 = mayorEvaluacion;
                        posicionMayorEvaluacion2 = posicionMayorEvaluacion;

                        mayorEvaluacion = combinaciones[i].evaluar();
                        posicionMayorEvaluacion=i;
                        Console.WriteLine("mayorEvaluacion");
                    }
                    else if (combinaciones[i].evaluar() > mayorEvaluacion2)
                    {
                        mayorEvaluacion2 = combinaciones[i].evaluar();
                        posicionMayorEvaluacion2 = i;
                        Console.WriteLine("mayorEvaluacion2");
                    }
                }

                if (mayorEvaluacion == 14)
                {
                    continuar = false;
                }
                else 
                {
                    Console.Clear();
                    Console.WriteLine(combinaciones[posicionMayorEvaluacion].cadena + "\tEvaluación: " + combinaciones[posicionMayorEvaluacion].evaluar());
                }

            }

            Console.Clear();
            Console.WriteLine(combinaciones[posicionMayorEvaluacion].cadena);
            Console.ReadLine();
        }

        class combinacion
        {
            public string cadena{get;set;}

            public combinacion(){
                for(int i=0;i<"charles darwin".Length;i++)
                {
                    cadena+=(char)('a' + (char)rand.Next(26) )+ "";
                }
            }

            public int evaluar()            
            {
                int puntuacion= 0;

                char[] caracteres = cadena.ToCharArray();
                char[] solucion = "charles darwin".ToCharArray();

                for(int i=0;i<solucion.Length;i++)
                {
                    if (i<caracteres.Length && solucion[i] == caracteres[i])
                    {
                        puntuacion++;
                    }
                }

                return puntuacion;
            }

            public string generarDescendencia(string pareja)
            {
                string nuevo = "";
                char[] caracteres = cadena.ToCharArray();
                char[] caracteresPareja = pareja.ToCharArray();

                for (int i = 0; i < caracteres.Length;i++ )
                {
                    if (cambio.Next(rand.Next(500)) == 1)
                    {
                        nuevo += (char)((char)rand.Next(400)) + "";
                    }
                    else
                    {
                        if (rand.Next(2) == 1)
                        {
                            nuevo += ((char)caracteres[i]);
                        }
                        else 
                        {
                            nuevo += ((char)caracteresPareja[i]);
                        }
                        
                    }
                }

                return nuevo;
            }
        }
    }
}
