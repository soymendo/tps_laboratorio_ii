using Entidades.Clases_especializadas;
using Entidades.Exepciones;
using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entidades.Clases_generales
{
    public class Sistema : IArchivoJson

    {
        public delegate void Cargar();
        public event Cargar CargarLista;
        
        
        

        private DatosGeneric<PlacaVideo> datosOriginales;

        private List<PlacaVideo> listaDePlacasACargarLado1;
        private List<PlacaVideo> listaDePlacasACargarLado2;
        private List<Comparar> comparaciones;
        private int capacidadDatosAAlmacenar;
        /// <summary>
        /// Contructor, inicializa la lista
        /// </summary>
        public Sistema()
        {
            this.datosOriginales = new DatosGeneric<PlacaVideo>();
            this.listaDePlacasACargarLado1 = new List<PlacaVideo>();
            this.comparaciones = new List<Comparar>();

            this.CargarLista += CargarPlacas;
            this.CargarLista += CargarDatos;
            this.CargarLista += CargarComparaciones;

            CargarLista.Invoke();

            this.listaDePlacasACargarLado2 = new List<PlacaVideo>(listaDePlacasACargarLado1);

        }

        /// <summary>
        /// Constructor , le paso un tamaño
        /// </summary>
        /// <param name="tamanio"></param>
        public Sistema(int tamanio)
        : this()
        {
            this.capacidadDatosAAlmacenar = tamanio;
        }

        /// <summary>
        /// Devuelve una lista con los datos de las placas 
        /// </summary>
        public List<PlacaVideo> ListaDatosPlacas
        {
            get { return this.datosOriginales.ListarHardware(); }
        }


        /// <summary>
        /// CAragamos  los datos de las placas desde afuera (xml o json)
        /// </summary>
        public List<PlacaVideo> ListaDePlacasACargarLado1
        {
            get { return this.listaDePlacasACargarLado1; }
            set { this.listaDePlacasACargarLado1 = value; }
        }


        /// <summary>
        /// CAragamos  los datos de las placas desde afuera (xml o json)
        /// </summary>
        public List<PlacaVideo> ListaDePlacasACargarLado2
        {
            get { return this.listaDePlacasACargarLado2; }
            set { this.listaDePlacasACargarLado2 = value; }
        }

        /// <summary>
        /// cargamos/vemos las comparaciones
        /// </summary>
        public List<Comparar> Comparaciones
        {
            get { return this.comparaciones; }
            set { this.comparaciones = value; }
        }

        /// <summary>
        /// DEvuelve el tamanio de los datos originales
        /// </summary>
        public int TamanioOriginales
        {
            get { return this.datosOriginales.CantidadDatos(); }
        }


        /// <summary>
        /// Verifico si el hardware esta en datosOriginalesPlacas
        /// </summary>
        /// <param name="s"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public static bool VerificarIngresoOri(Sistema s, Hardware h)
        {
            bool retorno = false;
            if (s.datosOriginales == h)
            {
                retorno = true;
            }
            return retorno;
        }


        /// <summary>
        /// Guardo los datos del hardware si no estan dentro de datosOriginalesPlacas
        /// </summary>
        /// <param name="s"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public static bool GuardarDatosOri(Sistema s, Hardware h)
        {
            bool retorno = false;
            if (!(VerificarIngresoOri(s, h)))
            {

                if (s.datosOriginales + h)
                { retorno = true; }

            }
            else
            {
                throw new NoAgregaDatosException("No se pudo agregar");
            }
            return retorno;
        }

        /// <summary>
        /// Muestra los datos originales
        /// </summary>
        /// <returns></returns>
        public string MostrarDatosOriginales()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(datosOriginales.MostrarDatos());
            return sb.ToString();
        }



        /// <summary>
        /// Agrgo los nuevos datos a la lista de datos nuevos del hardware
        /// </summary>
        /// <param name="h"></param>
        /// <param name="dato"></param>
        /// <param name="valor"></param>
        /// <returns>true si logra agregarlo</returns>
        public static bool AgregarDatosNuevos(Hardware h, string dato, int valor)
        {
            NuevosDatos nuevos = new NuevosDatos(dato, valor);


            bool retorno = false;

            if (!(Hardware.EncontrarNuevosDatos(nuevos, h)))
            {
                h.NuevosDatos.Add(nuevos);

                retorno = true;
            }
            else
            {
                throw new NoAgregaDatosException("Dato repetido, no se puede agregar");
            }

            return retorno;
        }


        /// <summary>
        /// verifico si la placa a crear ya esta o no en la la lista de placas a cargar
        /// </summary>
        /// <param name="p1"></param>
        /// <returns></returns>
        public bool VerificarPlaca(PlacaVideo p1)
        {
            bool retorno = false;
            foreach (PlacaVideo item in this.ListaDePlacasACargarLado1)
            {
                if (item == p1)
                {
                    retorno = true;
                }
            }
            return retorno;
        }


        /// <summary>
        /// Agrega a la lista de comparaciones el dato agregado 
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public bool VerificarIngresoDeDatosQueNoSeRepita(ComparaDatosNuevos c)
        {
            bool retorno = false;
            foreach (var item in this.Comparaciones)
            {
                if (item.ToString() == c.ToString())
                {
                    retorno = true;
                }
            }
            return retorno;
        }


        /// <summary>
        /// Guarda en formato json
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="contenido"></param>
        public void Guardar(string ruta, string contenido)
        {
            using (StreamWriter streamWriter = new StreamWriter(ruta))
            {
                string json = JsonSerializer.Serialize(contenido);
                streamWriter.Write(json);
            }
        }


        /// <summary>
        /// Carga los datos a la lista de placas
        /// </summary>
        public void CargarDatos()
        {

          
            foreach (PlacaVideo item in this.ListaDePlacasACargarLado1)
            {
                Random plac = new Random();
                Random ram = new Random();
                Random frec = new Random();
                Random cons = new Random();
                Random longi = new Random();
                Random inter = new Random();
                Random bit = new Random();
                Random ethe = new Random();

                item.TipoDeMemoria = (PlacaVideo.ETipoMemoria)(plac.Next(0, 4));
                item.CapacidadDeRam = ram.Next(1, 17);
                item.FrecuenciaDeMemoria = frec.Next(1, 17);
                item.Consumo = cons.Next(10, 101);
                item.Longitud = longi.Next(10, 36);
                item.Interfaz = inter.NextDouble() + inter.Next(1, 4);
                item.MineriaEthereum = ethe.NextDouble() * 0.1;
                item.MineriaBitcoin = bit.NextDouble() * 0.1;

            }

            
 

        }
        /// <summary>
        /// carga las placas a la lista de placas
        /// </summary>
        public void CargarPlacas()
        {
            listaDePlacasACargarLado1.Add(new PlacaVideo("GTX 100", Marca.EMarca.Gigabyte));
            listaDePlacasACargarLado1.Add(new PlacaVideo("GTX 200", Marca.EMarca.Asus));
            listaDePlacasACargarLado1.Add(new PlacaVideo("GTX 300", Marca.EMarca.Gigabyte));
            listaDePlacasACargarLado1.Add(new PlacaVideo("GTX 400", Marca.EMarca.Amd));
            listaDePlacasACargarLado1.Add(new PlacaVideo("GTX 500", Marca.EMarca.Gigabyte));
            listaDePlacasACargarLado1.Add(new PlacaVideo("GTX 600", Marca.EMarca.Intel));
            listaDePlacasACargarLado1.Add(new PlacaVideo("GTX 700", Marca.EMarca.Gigabyte));
            listaDePlacasACargarLado1.Add(new PlacaVideo("GTX 800", Marca.EMarca.Msi));
            listaDePlacasACargarLado1.Add(new PlacaVideo("GTX 900", Marca.EMarca.Gigabyte));
            listaDePlacasACargarLado1.Add(new PlacaVideo("GTX 1000", Marca.EMarca.Amd));

        }

        /// <summary>
        /// Carga las comparacione sen la lista de comparaciones
        /// </summary>
        public void CargarComparaciones()
        {
            this.Comparaciones.Add(new Memoria(new PlacaVideo(), new PlacaVideo()));
            this.Comparaciones.Add(new DatosGenerales(new PlacaVideo(), new PlacaVideo()));
            this.Comparaciones.Add(new Mineria(new PlacaVideo(), new PlacaVideo()));
            
        }

        /// <summary>
        /// Analizamos segun marca
        /// </summary>
        /// <param name="marca"></param>
        /// <returns></returns>
        public string AnalizarMarca(Marca.EMarca marca)
        {
            double cantLista = this.listaDePlacasACargarLado1.Count;
            List<PlacaVideo> listaAnalisis = new List<PlacaVideo>();
            listaAnalisis = this.listaDePlacasACargarLado1.FindAll((l) => l.Marca.MarcaProducto == marca);
            double cantAnalisis = listaAnalisis.Count;
            double analisisFinal;

            analisisFinal = (cantAnalisis * 100) / cantLista;

            return $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con la marca {marca}";

        }


        /// <summary>
        /// analizamos segun tipo de memoria
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public string AnalizarTipoMemoria(PlacaVideo.ETipoMemoria tipo)
        {
            double cantLista = this.listaDePlacasACargarLado1.Count;
            List<PlacaVideo> listaAnalisis = new List<PlacaVideo>();
            listaAnalisis = this.listaDePlacasACargarLado1.FindAll((l) => l.TipoDeMemoria == tipo);
            double cantAnalisis = listaAnalisis.Count;
            double analisisFinal;

            analisisFinal = (cantAnalisis * 100) / cantLista;

            return $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con tipo de memoria {tipo}";

        }


       

        /// <summary>
        /// analizamos segun ram
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public string AnalizarSegunRam(string datos)
        {
            string retorno = "";
            double cantLista = this.listaDePlacasACargarLado1.Count;
            List<PlacaVideo> listaAnalisis = new List<PlacaVideo>();
            double cantAnalisis;
            double analisisFinal;

            switch (datos)
            {
                case "entre 1 y 4 gb inclusive":
                    listaAnalisis = this.listaDePlacasACargarLado1.FindAll((l) => l.CapacidadDeRam >= 1 && l.CapacidadDeRam <= 4);
                    cantAnalisis = listaAnalisis.Count;
                    analisisFinal = (cantAnalisis * 100) / cantLista;

                    retorno = $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con ram entre 1 y 4 gb inclusive";
                    break;
                case "entre 4 y 8 gb inclusive":
                    listaAnalisis = this.listaDePlacasACargarLado1.FindAll((l) => l.CapacidadDeRam >= 4 && l.CapacidadDeRam <= 8);
                    cantAnalisis = listaAnalisis.Count;
                    analisisFinal = (cantAnalisis * 100) / cantLista;

                    retorno = $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con ram entre 4 y 8 gb inclusive";
                    break;
                case "entre 8 y 16 gb inclusive":
                    listaAnalisis = this.listaDePlacasACargarLado1.FindAll((l) => l.CapacidadDeRam >= 8 && l.CapacidadDeRam <= 16);
                    cantAnalisis = listaAnalisis.Count;
                    analisisFinal = (cantAnalisis * 100) / cantLista;

                    retorno = $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con ram entre 8 y 16 gb inclusive";
                    break;
                case "16gb o mas":
                    listaAnalisis = this.listaDePlacasACargarLado1.FindAll((l) => l.CapacidadDeRam >= 16 );
                    cantAnalisis = listaAnalisis.Count;
                    analisisFinal = (cantAnalisis * 100) / cantLista;

                    retorno = $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con ram mayor o igual a 16";
                    break;
            }

            return retorno;
        }

        /// <summary>
        /// analizamos segun el consumo
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public string AnalizarConsumo(string datos)
        {   
            string retorno = "";
            double cantLista = this.listaDePlacasACargarLado1.Count;
            List<PlacaVideo> listaAnalisis = new List<PlacaVideo>();
            double cantAnalisis;
            double analisisFinal;

            switch (datos)
            {
                case "entre 1 y 25 W inclusive":
                    listaAnalisis = this.listaDePlacasACargarLado1.FindAll((l) => l.Consumo >= 1 && l.Consumo <= 25);
                    cantAnalisis = listaAnalisis.Count;
                    analisisFinal = (cantAnalisis * 100) / cantLista;

                    retorno = $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con consumo entre 1 y 25 W inclusive";
                    break;
                case "entre 25 y 50 W inclusive":
                    listaAnalisis = this.listaDePlacasACargarLado1.FindAll((l) => l.Consumo >= 25 && l.Consumo <= 50);
                    cantAnalisis = listaAnalisis.Count;
                    analisisFinal = (cantAnalisis * 100) / cantLista;

                    retorno = $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con consumo entre 25 y 50 W inclusive";
                    break;
                case "entre 50 y 75 W inclusive":
                    listaAnalisis = this.listaDePlacasACargarLado1.FindAll((l) => l.Consumo >= 50 && l.Consumo <= 75);
                    cantAnalisis = listaAnalisis.Count;
                    analisisFinal = (cantAnalisis * 100) / cantLista;

                    retorno = $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con consumo entre 50 y 75 W inclusive";
                    break;
                case "entre 75 y 100 W inclusive":
                    listaAnalisis = this.listaDePlacasACargarLado1.FindAll((l) => l.Consumo >= 75 && l.Consumo <= 100);
                    cantAnalisis = listaAnalisis.Count;
                    analisisFinal = (cantAnalisis * 100) / cantLista;

                    retorno = $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con consumo entre 75 y 100 W inclusive";
                    break;
                case "100 W o mas":
                    listaAnalisis = this.listaDePlacasACargarLado1.FindAll((l) => l.CapacidadDeRam >= 100);
                    cantAnalisis = listaAnalisis.Count;
                    analisisFinal = (cantAnalisis * 100) / cantLista;

                    retorno = $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con consumo mayor o igual a 100 W";
                    break;
            }

            return retorno;
        }


    }
}
