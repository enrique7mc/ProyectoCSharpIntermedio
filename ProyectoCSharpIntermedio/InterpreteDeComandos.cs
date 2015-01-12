using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCSharpIntermedio
{
    public class InterpreteDeComandos
    {
        public static Comando Interpretar(string entrada)
        {
            var tokens = Split(entrada);
            if(tokens.Length == 0)
            {
                throw new ComandoInvalidoException("Comando no válido");
            }

            return new Comando(tokens[0], tokens.Skip(1).ToArray());
        }

        static string[] Split(string cadena)
        {
            return cadena.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
