using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCSharpIntermedio
{
    public class ExporadorDeArchivos
    {
        private DirectoryInfo _directoryInfo;

        public string DirectorioActual
        {
            get { return _directoryInfo.FullName; }
            private set { }
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

        private void Cls()
        {
            Console.Clear();
        }

        private void ListarContenidoDirectorio(string rutaDirectorio)
        {
            var contenido = new DirectoryInfo(rutaDirectorio).EnumerateFileSystemInfos();
            foreach(var entrada in contenido)
            {
                Console.WriteLine(entrada.Name);
            }
        }

        private void CambiarDirectorioActual(string rutaDirectorio)
        {
            DirectorioActual = rutaDirectorio;
        }
    }
}
