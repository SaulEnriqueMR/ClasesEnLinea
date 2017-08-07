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
    public class CuentaHandlerTests
    {
        [TestMethod()]
        public void iniciarSesionTest()
        {
            const string resultadoInicioEsperado = "SesionIniciada";
            CuentaHandler cuentaHandler = new CuentaHandler();
            var contrasenaCifrada = Utilidad.CifrarContrasena("saul");
            var resultadoObtenido = cuentaHandler.iniciarSesion("saul", contrasenaCifrada);
            string resultadoInicioObtenido;
            if (resultadoObtenido.IdCuenta > 0)
            {
                resultadoInicioObtenido = "SesionIniciada";
            }
            else
            {
                resultadoInicioObtenido = "SesionRechazada";
            }

            Assert.AreEqual(resultadoInicioEsperado, resultadoInicioObtenido);
        }

        [TestMethod()]
        public void registrarCuentaTest()
        {
            const string resultadoEsperado = "CuentaRegistrada";
            CuentaHandler cuentaHandler = new CuentaHandler();
            var contrasenaCifrada = Utilidad.CifrarContrasena("elrevo");
            TCuenta cuentaParaRegistrar = new TCuenta
            {
                Usuario = "elrevo",
                Contrasena = contrasenaCifrada,
                Nombre = "El Revo",
            };

            string resultadoObtenido = cuentaHandler.registrarCuenta(cuentaParaRegistrar);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}