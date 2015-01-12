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
                "dir", 
                @"cd C:\Users\Enrique", 
                @"copy C:\Users\Enrique\ex01.sql otro_archivo",
                "", 
                "   ", 
                "touch archivo"
            };

            List<Comando> resultados = new List<Comando>();

            foreach(var cadena in cadenas)
            {
                try
                {
                    var c = InterpreteDeComandos.Interpretar(cadena);
                    resultados.Add(c);
                }
                catch(ComandoInvalidoException ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }

            Assert.AreEqual(4, resultados.Count);
        }
    }
}
