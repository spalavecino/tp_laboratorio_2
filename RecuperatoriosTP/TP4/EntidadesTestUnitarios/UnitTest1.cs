using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;

namespace EntidadesTestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Instanciacion_De_Paquetes_En_Correo()
        {
            Correo correo;

            correo = new Correo();

            Assert.IsNotNull(correo.Paquetes);
        }
        
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void No_Paquetes_Mismo_Tracking_ID()
        {
            Correo correo;

            correo = new Correo();
            Paquete paquete1 = new Paquete("Direccion 1", "1234");
            Paquete paquete2 = new Paquete("Direccion 2", "1234");
            correo += paquete1;
            correo += paquete2;            
        }
    }
}
