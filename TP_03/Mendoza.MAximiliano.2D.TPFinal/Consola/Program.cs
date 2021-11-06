using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Entidades;
using Entidades.Archivos;
using Entidades.Clases_especializadas;
using Entidades.Clases_generales;
using Entidades.Exepciones;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string rutaArchivo = Path.Combine(rutaEscritorio, "placa");
            PlacaVideo pAux=new PlacaVideo();

       
            PlacaVideo p1 = new PlacaVideo("GTX 550ti",Marca.EMarca.Gigabyte);
            PlacaVideo p2 = new PlacaVideo("GTX 650ti", Marca.EMarca.Gigabyte);
            PlacaVideo p3 = new PlacaVideo("GTX 550ti", Marca.EMarca.Gigabyte);
           
            Sistema s1 = new Sistema(10);


         

            string datoAgregado = "Tamanio";
            string datoAgregado2 = "Tamanio";

            try
            {
                p1.TipoDeMemoria = PlacaVideo.ETipoMemoria.GDDR5;
                p1.CapacidadDeRam = 16;
                p1.FrecuenciaDeMemoria = 1000;

                p1.Consumo = 65;
                p1.Longitud = 25;
                p1.Interfaz = 3.1f;

                p1.MineriaBitcoin = 0.6f;
                p1.MineriaEthereum = 0.12f;
                Sistema.AgregarDatosNuevos(p1, datoAgregado, 14);
                Sistema.AgregarDatosNuevos(p1, datoAgregado2, 14);
                // Sistema.AgregarDatosNuevos(p1, "mineria", 6);


                p2.TipoDeMemoria = PlacaVideo.ETipoMemoria.GDDR1;
                p2.CapacidadDeRam = 6;
                p2.FrecuenciaDeMemoria = 1800;

                p2.Consumo = 85;
                p2.Longitud = 5;
                p2.Interfaz = 0.1f;


                Sistema.AgregarDatosNuevos(p2, datoAgregado, 5);
                Sistema.AgregarDatosNuevos(p2, datoAgregado2, 5);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); ;
               
            }
          
            // Sistema.AgregarDatosNuevos(p1, "mineria", 6);

            p2.MineriaBitcoin = 0.6f;
            p2.MineriaEthereum = 0.2f;

          
             s1.Comparaciones.Add(new ComparaDatosNuevos(p1, p2, datoAgregado2));//simular con un boton en formulario,
           
          







            Console.WriteLine(s1.Comparaciones[0].Mostrar(p1,p2));
            Console.WriteLine(s1.Comparaciones[1].Mostrar(p1, p2));
            Console.WriteLine(s1.Comparaciones[2].Mostrar(p1,p2));
            Console.WriteLine(s1.Comparaciones[3].Mostrar(p1,p2,datoAgregado));
           // Console.WriteLine(s1.Comparaciones[4].Mostrar(p1, p2, datoAgregado2));

            //Console.WriteLine(s1.CompararMemoria(p1,p2));



            //  try
            // {
            //Sistema.GuardarDatosOri(s1, p1);
            //Sistema.GuardarDatosOri(s1, p2);
            // Sistema.GuardarDatosOri(s1, p3);

            //if (!File.Exists(ruta))
            //{
            //   File.Create(ruta);
            //}
            // ruta = Path.Combine(ruta,"placa.xml");
            //if (!Directory.Exists(rutaArchivo))
            //{
            //    Directory.CreateDirectory(rutaArchivo);
            //}
            //rutaArchivo= Path.Combine(rutaArchivo, "placa.xml");
            //p1.Guardar(ruta);
            //p2.Guardar(ruta);


            Texto txt = new Texto();
            string nombreDeDato = s1.Comparaciones[0].ToString();
            txt.Datos = $"{s1.Comparaciones[0].Mostrar(p1, p2)}";
            txt.Guardar(ruta + $".\\{nombreDeDato}.txt");

            //pAux = pAux.DeserializarDesdeXml<PlacaVideo>(ruta);
            //Console.WriteLine(pAux.Informar());

            //  }
            // catch (NoAgregaDatosException ex)
            // {

            //    Console.WriteLine(ex.Message);
            //  }


            // p1.DatoNuevo.Add("mine");
            //p1.ValorDatoNuevo.Add(55);

            //p2.DatoNuevo.Add("mine");
            //p2.ValorDatoNuevo.Add(51);

            //Sistema.AgregarDatosNuevos(p1, "Tamanio", 4);
            //Sistema.AgregarDatosNuevos(p2, "Tamanio", 5);

            //if (Sistema.AgregarDatosNuevos(p1, "Tamanio", 5)) { }
            // // if (Sistema.AgregarDatosNuevos(p1, "Tam", 6)) { } else { Console.WriteLine("repetido"); }
            // if (Sistema.AgregarDatosNuevos(p2, "Tamanio", 5)) { }

            //  if (Sistema.AgregarDatosNuevos(p1, "mineria", 6)) { }
            //if (Sistema.AgregarDatosNuevos(p1, "mineria", 5)) { } else { Console.WriteLine("repetido"); }
            //  if (Sistema.AgregarDatosNuevos(p2, "mineria", 5)) { }

            //  if (Sistema.AgregarDatosNuevos(p1, "fps", 15)) { }
            //if (Sistema.AgregarDatosNuevos(p1, "mineria", 5)) { } else { Console.WriteLine("repetido"); }
            //  if (Sistema.AgregarDatosNuevos(p2, "fps", 5)) { }
            //Console.WriteLine(p1.ToString());
            // Console.WriteLine(s1.CompararMemoria(p1, p2));
            // Console.WriteLine(s1.CompararDatosNuevos(p1,p2, "fps"));
            // Console.WriteLine(s1.MostrarDatosOriginales());


            // Console.WriteLine(s1.CompararDatosGenerales(p1,p2));
            // Console.WriteLine(s1.CompararMineria(p1, p2));


        }
    }
}
