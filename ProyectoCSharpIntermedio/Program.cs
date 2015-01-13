using System;
using System.Collections.Generic;
using System.IO;
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
            while(true)
            {
                try
                {
                    string entrada = Promt();
                    Exporador.EjecutaComando(InterpreteDeComandos.Interpretar(entrada));
                }
                catch(ComandoInvalidoException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(IOException e)
                {
                    Console.WriteLine("Ocurrió un error: {0}", e.Message);
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
