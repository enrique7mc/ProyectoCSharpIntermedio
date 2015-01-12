using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCSharpIntermedio
{
    class Program
    {
        private static readonly ExporadorDeArchivos Exporador = 
            new ExporadorDeArchivos(@"C:\Users\Enrique\Documents");

        static void Main(string[] args)
        {
            string entrada;
            while(true)
            {
                try
                {
                    entrada = Promt();
                    Exporador.EjecutaComando(InterpreteDeComandos.Interpretar(entrada));
                }
                catch(ComandoInvalidoException e)
                {
                    Console.WriteLine(e.Message);                    
                }
            }
        }

        static string Promt()
        {
            Console.Write(Exporador.DirectorioActual + "> ");
            return Console.ReadLine();
        }
    }
}
