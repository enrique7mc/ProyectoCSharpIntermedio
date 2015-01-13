using System;
using System.IO;

namespace ProyectoCSharpIntermedio
{
    public class ExporadorDeArchivos
    {
        private DirectoryInfo _directoryInfo;

        public string DirectorioActual
        {
            get { return _directoryInfo.FullName; }
        }

        public ExporadorDeArchivos(string directorioActual)
        {
            _directoryInfo = new DirectoryInfo(directorioActual);
        }

        public void EjecutaComando(Comando comando)
        {
            switch(comando.Instruccion)
            {
                case Instrucciones.Dir:
                    Dir(comando.Argumentos);
                    break;  
                case Instrucciones.Cd:
                    Cd(comando.Argumentos);
                    break;
                case Instrucciones.Touch:
                    Touch(comando.Argumentos);
                    break;
                case Instrucciones.Copy:
                    Copy(comando.Argumentos);
                    break;
                case Instrucciones.Move:
                    Move(comando.Argumentos);
                    break;
                case Instrucciones.Cls:
                    Cls();
                    break;
                case Instrucciones.Exit:
                    Environment.Exit(0);
                    break;
            }
        }

        private void Dir(string[] argumentos)
        {
            ListarContenidoDirectorio(argumentos.Length == 1 ? argumentos[0] : DirectorioActual);
        }

        private void Cd(string[] argumentos)
        {            
            switch(argumentos[0])
            {
                case "..":
                    if(_directoryInfo.Parent != null)
                    {
                        _directoryInfo = new DirectoryInfo(_directoryInfo.Parent.FullName);
                    }
                    break;
                default:
                    _directoryInfo = new DirectoryInfo(argumentos[0]);
                    break;
            }
        }

        private static void Cls()
        {
            Console.Clear();
        }

        private void Touch(string[] argumentos)
        {
            using(File.Create(Path.Combine(DirectorioActual, argumentos[0])));
        }

        private static void Copy(string[] argumentos)
        {            
            File.Copy(argumentos[0], argumentos[1], false);            
        }

        private static void Move(string[] argumentos)
        {
            File.Move(argumentos[0], argumentos[1]);
        }

        private static void ListarContenidoDirectorio(string rutaDirectorio)
        {
            var contenido = new DirectoryInfo(rutaDirectorio).EnumerateFileSystemInfos();
            foreach(var entrada in contenido)
            {
                Console.WriteLine(entrada.Name);
            }
        }
    }
}
