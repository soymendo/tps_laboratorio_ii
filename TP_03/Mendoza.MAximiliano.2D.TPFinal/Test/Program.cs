using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Entidades;
using Entidades.Archivos;
using Entidades.Clases_especializadas;
using Entidades.Clases_generales;
using Entidades.Exepciones;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //creo el sistema
            Sistema s1 = new Sistema(10000);


            //creamos las placas
            PlacaVideo p1 = new PlacaVideo("GTX 1050ti", Marca.EMarca.Gigabyte);
            PlacaVideo p2 = new PlacaVideo("GTX 650ti", Marca.EMarca.Gigabyte);
            PlacaVideo p3 = new PlacaVideo("GTX 950ti", Marca.EMarca.Gigabyte);


            //creamos los datos nuevos a cargarle a las placas
            string datoAgregado1 = "Tamanio";
            string datoAgregado2 = "Tamanio";

            string datoAgregado3 = "Coolers";


            //cargamos todos los datos a las placas, si dos datos nuevos son iguales , lanza la exepcion: NoAgregaDatosException
          
                p1.TipoDeMemoria = PlacaVideo.ETipoMemoria.GDDR5;
                p1.CapacidadDeRam = 16;
                p1.FrecuenciaDeMemoria = 1000;

                p1.Consumo = 65;
                p1.Longitud = 25;
                p1.Interfaz = 3.1f;

                p1.MineriaBitcoin = 0.6f;
                p1.MineriaEthereum = 0.12f;

            try
            {
                Sistema.AgregarDatosNuevos(p1, datoAgregado1, 14);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            try
            {
             
                Sistema.AgregarDatosNuevos(p1, datoAgregado2, 14);            
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            try
            {

                Sistema.AgregarDatosNuevos(p1, datoAgregado3, 2);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }


                p2.TipoDeMemoria = PlacaVideo.ETipoMemoria.GDDR1;
                p2.CapacidadDeRam = 6;
                p2.FrecuenciaDeMemoria = 1800;

                p2.Consumo = 85;
                p2.Longitud = 5;
                p2.Interfaz = 0.1f;

                try
                {
                    Sistema.AgregarDatosNuevos(p2, datoAgregado1, 5);
                    
                }
                catch (Exception e )
                {

                    Console.WriteLine(e.Message);
                }

            try
            {
             
                Sistema.AgregarDatosNuevos(p2, datoAgregado2, 5);
               
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            try
            {

                Sistema.AgregarDatosNuevos(p2, datoAgregado3, 2);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }



            //Agrega el dato nuevo a la lista de comparaciones del sistema s1 para comparar

            s1.Comparaciones.Add(new ComparaDatosNuevos(p1, p2));
            s1.Comparaciones.Add(new ComparaDatosNuevos(p1, p2));


            //Muestro toda las comparaciones desde la lista de comparaciones de s1
            Console.WriteLine(s1.Comparaciones[0].Mostrar(p1, p2));
            Console.WriteLine(s1.Comparaciones[1].Mostrar(p1, p2));
            Console.WriteLine(s1.Comparaciones[2].Mostrar(p1, p2));
            s1.Comparaciones[3].Dato = datoAgregado1;
            Console.WriteLine(s1.Comparaciones[3].Mostrar(p1,p2));
            s1.Comparaciones[4].Dato = datoAgregado3;
            Console.WriteLine(s1.Comparaciones[4].Mostrar(p1, p2));



            //Guardo alguna comparacion solicitada (mineria en este caso)

            Texto txt = new Texto();
            string nombreDeDato = s1.Comparaciones[0].ToString();
            txt.Datos = $"{s1.Comparaciones[0].Mostrar(p1, p2)}";

            try
            {
                txt.Guardar(ruta + $".\\{nombreDeDato}.txt");
            }
            catch (Exception exe)
            {

                Console.WriteLine(exe.Message);
            }





            //Guardamos las placas en formato XML en escritorio

            p1.Guardar(ruta);
            p2.Guardar(ruta);


            // Cargamos las placas desde el escritorio

            PlacaVideo pAux1 = new PlacaVideo();
            PlacaVideo pAux2 = new PlacaVideo();
            try
            {
                pAux1 = pAux1.Leer<PlacaVideo>(ruta + $".\\GTX 1050ti.xml");
            }
            catch (Exception exe)
            {

                Console.WriteLine(exe.Message);
            }

            try
            {
                pAux2 = pAux2.Leer<PlacaVideo>(ruta + $".\\GTX 650ti.xml");
            }
            catch (Exception exa)
            {

                Console.WriteLine(exa.Message);
            }



            //vemos las placas cargadas

            try
            {
                Console.WriteLine(pAux1.Informar());
            }
            catch (Exception esx)
            {

                Console.WriteLine(esx.Message);
            }

            try
            {
                Console.WriteLine(pAux2.Informar());
            }
            catch (Exception esx)
            {

                Console.WriteLine(esx.Message);
            }
            
           



        }
    }
}
