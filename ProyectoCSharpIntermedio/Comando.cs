using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProyectoCSharpIntermedio
{
    public class Comando
    {
        public Instrucciones Instruccion { get; set; }
        public IEnumerable<string> Argumentos { get; set; }

        public Comando(string instruccion, string[] argumentos)
        {
            ValidaInstruccion(instruccion);
            ValidaNumeroArgumentos(argumentos);
            ValidaArgumentos(argumentos);

            Argumentos = argumentos;
        }

        private void ValidaInstruccion(string instruccion)
        {
            Instrucciones ins;
            if(Enum.TryParse(instruccion, true, out ins))
            {
                Instruccion = ins;
            }
            else
            {
                throw new ComandoInvalidoException("Comando no válido");
            }
        }

        private void ValidaNumeroArgumentos(string[] argumentos)
        {
            switch(Instruccion)
            {
                case Instrucciones.Dir:
                case Instrucciones.Cd:
                    if(argumentos.Length > 1)
                    {
                        throw new ComandoInvalidoException
                            (string.Format("El comando {0} recibe hasta 1 argumento", Instruccion));
                    }
                    break;
                case Instrucciones.Touch:
                    if(argumentos.Length != 1)
                    {
                        throw new ComandoInvalidoException
                            (string.Format("El comando {0} recibe 1 argumento", Instruccion));
                    }
                    break;
                case Instrucciones.Copy:
                case Instrucciones.Move:
                    if(argumentos.Length != 2)
                    {
                        throw new ComandoInvalidoException
                            (string.Format("El comando {0} recibe 2 argumentos", Instruccion));
                    }
                    break;
            }
        }

        private void ValidaArgumentos(string[] argumentos)
        {
            switch (Instruccion)
            {
                case Instrucciones.Dir:
                    if (argumentos.Length == 1 && !Directory.Exists(argumentos[0]))
                    {
                        throw new ComandoInvalidoException
                            (string.Format("El directorio {0} no existe", argumentos[0]));
                    }
                    break;
                case Instrucciones.Cd:
                    if (argumentos.Length == 1 && (!Directory.Exists(argumentos[0]) || argumentos[0] != ".."))
                    {
                        throw new ComandoInvalidoException
                            (string.Format("El directorio {0} no existe", argumentos[0]));
                    }
                    break;
                case Instrucciones.Copy:
                case Instrucciones.Move:
                    if (!File.Exists(argumentos[0]))
                    {
                        throw new ComandoInvalidoException
                            (string.Format("El archivo {0} no existe", argumentos[0]));
                    }
                    break;
            }
        }
    }

    public enum Instrucciones
    {
        Dir,
        Cd,
        Copy,
        Move,
        Touch
    }
}
