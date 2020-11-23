using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;
using System.IO;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest
    {

        /// <summary>
        /// Testear que el metodo de extensión funcione
        /// </summary>
        [TestMethod]
        public void TestFormatearPrecio()
        {
            // Arrange
            double numero = 2040.567;
            // Act
            string numeroFormateado = numero.FormatearPrecio();
            // Assert
            Assert.IsTrue(numeroFormateado == "$ 2.040,57");
        }


        /// <summary>
        /// Chequear que es la mismo info cuando serializo que cuando la leo
        /// </summary>
        [TestMethod]
        public void CuandoSerializoDeberiaGuardarCorrectamente()
        {
            Producto p = new Buzo(1, 'm', 1245, "Rojo", 2, "Buzo", "algodon");

            Serializador <Venta> ser = new Serializador<Venta>();

            Venta v = new Venta(p,2);
            v.Producto= p;
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), String.Format(@"VentaPrueba.bin"));

            ser.SerializarBinario(v, ruta);

            Venta v2 = new Venta();
            v2 = ser.DeserializarBinario(ruta);


            Assert.IsTrue(v.Fecha == v2.Fecha && v.Cantidad == v2.Cantidad);
        }
    }
}
