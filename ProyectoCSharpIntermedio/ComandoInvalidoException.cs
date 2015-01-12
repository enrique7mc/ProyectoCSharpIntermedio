using System;

namespace ProyectoCSharpIntermedio
{
    public class ComandoInvalidoException : Exception
    {
        public ComandoInvalidoException()
        {
        }

        public ComandoInvalidoException(string message) : base(message)
        {
        }

        public ComandoInvalidoException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
