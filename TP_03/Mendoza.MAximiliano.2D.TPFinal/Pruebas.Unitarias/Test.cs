using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Entidades.Clases_especializadas;
using Entidades.Clases_generales;
using Entidades.Exepciones;

namespace Pruebas.Unitarias
{
    [TestClass]
    public class Test
    {

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void CompararTipoDeMemoria_DeberiaDevolverUnString()
        {
            Sistema s1 = new Sistema(10);
            PlacaVideo p1 = new PlacaVideo("GTX 550ti", Marca.EMarca.Gigabyte);
            PlacaVideo p2 = new PlacaVideo("GTX 650ti", Marca.EMarca.Gigabyte);
            string valoresComparados;

            valoresComparados=s1.Comparaciones[0].Mostrar(p1, p2);

            Assert.IsNotNull(valoresComparados);
           
        }

        [TestMethod]
        public void AgregarDatosNuevos_DeberiaDevolverTrueSiAgregaBien()
        {
           
            PlacaVideo p1 = new PlacaVideo("GTX 550ti", Marca.EMarca.Gigabyte);
            string dato = "Tamanio";
            int valor = 5;
            bool retorno = false;

            if(Sistema.AgregarDatosNuevos( p1,dato,valor)) { retorno = true; }

            Assert.IsTrue(retorno);
           
        }


        [TestMethod]
        [ExpectedException(typeof(NoAgregaDatosException))]
        public void GuardarDatos_DeberiaTirarExeptionSiNoAgrego()
        {
            Sistema s1 = new Sistema(10);
            PlacaVideo p1 = new PlacaVideo("GTX 550ti", Marca.EMarca.Gigabyte);
            PlacaVideo p2 = new PlacaVideo("GTX 650ti", Marca.EMarca.Gigabyte);
            PlacaVideo p3 = new PlacaVideo("GTX 550ti", Marca.EMarca.Gigabyte);

            Sistema.GuardarDatosOri(s1, p1);
            Sistema.GuardarDatosOri(s1, p2);
            Sistema.GuardarDatosOri(s1, p3);

        }
    }
}
