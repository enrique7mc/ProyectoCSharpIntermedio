using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoCSharpIntermedio;

namespace ProyectoTests
{
    [TestClass]
    public class InterpreteTests
    {

        [TestMethod]
        public void PruebaInterprete()
        {
            string[] cadenas =
            {
                "dir", "cd directorio", "copy archivo otro archivo",
                "", "   ", "touch archivo"
            };

            List<Comando> resultados = new List<Comando>();

            foreach(var cadena in cadenas)
            {
                resultados.Add(InterpreteDeComandos.Interpretar(cadena));
            }

            Assert.AreEqual(4, resultados.Count);
        }
    }
}
