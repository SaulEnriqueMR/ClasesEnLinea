using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThriftHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriftStructs;

namespace ThriftHandlers.Tests
{
    [TestClass()]
    public class ExperienciaEducativaHandlerTests
    {
        [TestMethod()]
        public void registrarEETest()
        {
            const string resultadoEsperado = "EERegistrada";
            TExperienciaEducativa nuevaExperiencia = new TExperienciaEducativa
            {
                Nombre = "Requerimientos de Software",
            };
            ExperienciaEducativaHandler eeHandler = new ExperienciaEducativaHandler();

            string resultadoObtenido = eeHandler.registrarEE(nuevaExperiencia);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}