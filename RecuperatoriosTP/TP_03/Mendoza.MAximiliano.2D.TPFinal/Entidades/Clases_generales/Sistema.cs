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
            CargarPlacas();
            CargarDatos();
            CargarComparaciones();
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


            listaDePlacasACargarLado1.AddRange(new PlacaVideo[]

                                       {
                                        new PlacaVideo("GTX 100", Marca.EMarca.Gigabyte),
                                        new PlacaVideo("GTX 200", Marca.EMarca.Asus),
                                        new PlacaVideo("GTX 300", Marca.EMarca.Gigabyte),
                                        new PlacaVideo("GTX 400", Marca.EMarca.Amd),
                                        new PlacaVideo("GTX 500", Marca.EMarca.Gigabyte),
                                        new PlacaVideo("GTX 600", Marca.EMarca.Intel),
                                        new PlacaVideo("GTX 700", Marca.EMarca.Gigabyte),
                                        new PlacaVideo("GTX 800", Marca.EMarca.Msi),
                                        new PlacaVideo("GTX 900", Marca.EMarca.Gigabyte),
                                        new PlacaVideo("GTX 1000", Marca.EMarca.Amd),
                                        new PlacaVideo("GTX 1100", Marca.EMarca.Gigabyte),
                                        new PlacaVideo("GTX 1200", Marca.EMarca.Asus),
                                        new PlacaVideo("GTX 1300", Marca.EMarca.Gigabyte),
                                        new PlacaVideo("GTX 1400", Marca.EMarca.Amd),
                                        new PlacaVideo("GTX 1500", Marca.EMarca.Gigabyte),
                                        new PlacaVideo("GTX 1600", Marca.EMarca.Intel),
                                        new PlacaVideo("GTX 1700", Marca.EMarca.Gigabyte),
                                        new PlacaVideo("GTX 1800", Marca.EMarca.Msi),
                                        new PlacaVideo("GTX 1900", Marca.EMarca.Gigabyte),
                                        new PlacaVideo("GTX 2000", Marca.EMarca.Amd)
                                       });

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
  
            listaAnalisis = BuscarSegunPlaca(this.listaDePlacasACargarLado1,marca);
            double cantAnalisis = listaAnalisis.Count;
            double analisisFinal;

            analisisFinal = (cantAnalisis * 100) / cantLista;

            return $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con la marca {marca}";

        }


        /// <summary>
        /// obtiene una lista de placas segun el tipo de marca dado
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="eTipo"></param>
        /// <returns></returns>
        public List<PlacaVideo> BuscarSegunPlaca(List<PlacaVideo> lista, Marca.EMarca marca)
        {
            List<PlacaVideo> retorno = new List<PlacaVideo>();

            foreach (var item in lista)
            {
                if (item.Marca.MarcaProducto == marca)
                {
                    retorno.Add(item);
                }
            }

            return retorno;

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
            listaAnalisis = BuscarSegunTipoMemoria(this.listaDePlacasACargarLado1, tipo);
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
                    listaAnalisis = listaRam(this.listaDePlacasACargarLado1, 1, 4);
                    cantAnalisis = listaAnalisis.Count;
                    analisisFinal = (cantAnalisis * 100) / cantLista;

                    retorno = $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con ram entre 1 y 4 gb inclusive";
                    break;
                case "entre 4 y 8 gb inclusive":
                    listaAnalisis = listaRam(this.listaDePlacasACargarLado1, 4, 8);
                    cantAnalisis = listaAnalisis.Count;
                    analisisFinal = (cantAnalisis * 100) / cantLista;

                    retorno = $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con ram entre 4 y 8 gb inclusive";
                    break;
                case "entre 8 y 16 gb inclusive":
                    listaAnalisis = listaRam(this.listaDePlacasACargarLado1, 8, 16);
                    cantAnalisis = listaAnalisis.Count;
                    analisisFinal = (cantAnalisis * 100) / cantLista;

                    retorno = $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con ram entre 8 y 16 gb inclusive";
                    break;
                case "16gb o mas":
                    listaAnalisis = listaRam(this.listaDePlacasACargarLado1,16);
                    cantAnalisis = listaAnalisis.Count;
                    analisisFinal = (cantAnalisis * 100) / cantLista;

                    retorno = $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con ram mayor o igual a 16";
                    break;
            }

            return retorno;
        }



        /// <summary>
        /// Metodo que devuelve una lista de placas segun los valores de capacidad de ram proporcionados
        /// </summary>
        /// <param name="listaLado1"></param>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>

        private List<PlacaVideo> listaRam(List<PlacaVideo> listaLado1, int num1, int num2)
        {
            List<PlacaVideo> retorno = new List<PlacaVideo>();

            foreach (var item in listaLado1)
            {
                if ((item.CapacidadDeRam >= num1 && item.CapacidadDeRam <= num2))
                {
                    retorno.Add(item);
                }

            }
            return retorno;
        }

        /// <summary>
        /// Metodo que devuelve una lista de placas segun los valores de de capacidad de ram proporcionados
        /// </summary>
        /// <param name="listaLado1"></param>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        private List<PlacaVideo> listaRam(List<PlacaVideo> listaLado1, int num)
        {
            List<PlacaVideo> retorno = new List<PlacaVideo>();

            foreach (var item in listaLado1)
            {
                if (item.CapacidadDeRam >= num)
                {
                    retorno.Add(item);
                }

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
                  
                    listaAnalisis = lista(this.listaDePlacasACargarLado1,1,25);
                    cantAnalisis = listaAnalisis.Count;
                    analisisFinal = (cantAnalisis * 100) / cantLista;

                    retorno = $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con consumo entre 1 y 25 W inclusive";
                    break;
                case "entre 25 y 50 W inclusive":
               
                    listaAnalisis = lista(this.listaDePlacasACargarLado1, 25, 50);
                    cantAnalisis = listaAnalisis.Count;
                    analisisFinal = (cantAnalisis * 100) / cantLista;

                    retorno = $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con consumo entre 25 y 50 W inclusive";
                    break;
                case "entre 50 y 75 W inclusive":
                   
                    listaAnalisis = lista(this.listaDePlacasACargarLado1, 50, 75);
                    cantAnalisis = listaAnalisis.Count;
                    analisisFinal = (cantAnalisis * 100) / cantLista;

                    retorno = $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con consumo entre 50 y 75 W inclusive";
                    break;
                case "entre 75 y 100 W inclusive":
                   
                    listaAnalisis = lista(this.listaDePlacasACargarLado1, 75, 100);
                    cantAnalisis = listaAnalisis.Count;
                    analisisFinal = (cantAnalisis * 100) / cantLista;

                    retorno = $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con consumo entre 75 y 100 W inclusive";
                    break;
                case "100 W o mas":
                    listaAnalisis = lista(this.listaDePlacasACargarLado1, 100);
                    cantAnalisis = listaAnalisis.Count;
                    analisisFinal = (cantAnalisis * 100) / cantLista;

                    retorno = $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con consumo mayor o igual a 100 W";
                    break;
            }

            return retorno;
        }



        /// <summary>
        /// Metodo que devuelve una lista de placas segun los valores de consumo proporcionados
        /// </summary>
        /// <param name="listaLado1"></param>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>

        private List<PlacaVideo> lista(List<PlacaVideo> listaLado1, int num1, int num2)
        {
            List<PlacaVideo> retorno = new List<PlacaVideo>();

            foreach (var item in listaLado1)
            {
                if ((item.Consumo >= num1 && item.Consumo <= num2))
                {
                    retorno.Add(item);
                }

            }
            return retorno;
        }

        /// <summary>
        /// Metodo que devuelve una lista de placas segun los valores de consumo proporcionados
        /// </summary>
        /// <param name="listaLado1"></param>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        private List<PlacaVideo> lista(List<PlacaVideo> listaLado1, int num)
        {
            List<PlacaVideo> retorno = new List<PlacaVideo>();

            foreach (var item in listaLado1)
            {
                if (item.Consumo >= num)
                {
                    retorno.Add(item);
                }

            }
            return retorno;
        }





        /// <summary>
        /// Analiza, segun la placa selecciona, la comparacion de meoria ram entre el resto de las placas
        /// </summary>
        /// <param name="marca"></param>
        /// <returns></returns>
        public string AnalizarPlacaSegunRam(Marca.EMarca marca)
        {


            List<PlacaVideo> listaMsi = new List<PlacaVideo>();
            List<PlacaVideo> listaAsus = new List<PlacaVideo>();
            List<PlacaVideo> listaGigabyte = new List<PlacaVideo>();
            List<PlacaVideo> listaIntel = new List<PlacaVideo>();
            List<PlacaVideo> listaAmd = new List<PlacaVideo>();

            float promedioMsi = 0;
            float promedioAsus = 0;
            float promedioGigabyte = 0;
            float promedioIntel = 0;
            float promedioAmd = 0;

            listaMsi = BuscarSegunPlaca(this.listaDePlacasACargarLado1, Marca.EMarca.Msi);
            listaAsus = BuscarSegunPlaca(this.listaDePlacasACargarLado1, Marca.EMarca.Asus);
            listaGigabyte = BuscarSegunPlaca(this.listaDePlacasACargarLado1, Marca.EMarca.Gigabyte);
            listaIntel = BuscarSegunPlaca(this.listaDePlacasACargarLado1, Marca.EMarca.Intel);
            listaAmd = BuscarSegunPlaca(this.listaDePlacasACargarLado1, Marca.EMarca.Amd);

            promedioMsi = CalcularPromedioRam(listaMsi);
            promedioAsus = CalcularPromedioRam(listaAsus);
            promedioGigabyte = CalcularPromedioRam(listaGigabyte);
            promedioIntel = CalcularPromedioRam(listaIntel);
            promedioAmd = CalcularPromedioRam(listaAmd);


            StringBuilder sb = new StringBuilder();



            if (marca == Marca.EMarca.Msi)
            {
                sb.AppendLine($"{marca} tiene un promedio de ram de {string.Format("{0:0.00}", promedioMsi)}gb, esto significa : ");
                sb.AppendLine($"{CalcularPorcentaje(promedioMsi, promedioAsus)} que {Marca.EMarca.Asus}, el cual tiene un promedio de {promedioAsus}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioMsi, promedioGigabyte)} que {Marca.EMarca.Gigabyte}, el cual tiene un promedio de {promedioGigabyte}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioMsi, promedioIntel)} que {Marca.EMarca.Intel}, el cual tiene un promedio de {promedioIntel}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioMsi, promedioAmd)} que {Marca.EMarca.Amd}, el cual tiene un promedio de {promedioAmd}gb");
            }

            if (marca == Marca.EMarca.Asus)
            {
                sb.AppendLine($"{marca} tiene un promedio de ram de {string.Format("{0:0.00}", promedioAsus)}gb, esto significa : ");
                sb.AppendLine($"{CalcularPorcentaje(promedioAsus, promedioGigabyte)} que {Marca.EMarca.Gigabyte}, el cual tiene un promedio de {promedioGigabyte}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioAsus, promedioIntel)} que {Marca.EMarca.Intel}, el cual tiene un promedio de {promedioIntel}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioAsus, promedioAmd)} que {Marca.EMarca.Amd}, el cual tiene un promedio de {promedioAmd}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioAsus, promedioMsi)} que {Marca.EMarca.Msi}, el cual tiene un promedio de {promedioMsi}gb");
            }

            if (marca == Marca.EMarca.Gigabyte)
            {
                sb.AppendLine($"{marca} tiene un promedio de ram de {string.Format("{0:0.00}", promedioGigabyte)}gb, esto significa : ");
                sb.AppendLine($"{CalcularPorcentaje(promedioGigabyte, promedioIntel)} que {Marca.EMarca.Intel}, el cual tiene un promedio de {promedioIntel}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioGigabyte, promedioAmd)} que {Marca.EMarca.Gigabyte}, el cual tiene un promedio de {promedioAmd}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioGigabyte, promedioMsi)} que {Marca.EMarca.Msi}, el cual tiene un promedio de {promedioMsi}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioGigabyte, promedioAsus)} que {Marca.EMarca.Asus}, el cual tiene un promedio de {promedioAsus}gb");
            }

            if (marca == Marca.EMarca.Intel)
            {
                sb.AppendLine($"{marca} tiene un promedio de ram de {string.Format("{0:0.00}", promedioIntel)}gb, esto significa : ");
                sb.AppendLine($"{CalcularPorcentaje(promedioIntel, promedioAmd)} que {Marca.EMarca.Amd}, el cual tiene un promedio de {promedioAmd}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioIntel, promedioMsi)} que {Marca.EMarca.Msi}, el cual tiene un promedio de {promedioMsi}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioIntel, promedioAsus)} que {Marca.EMarca.Asus}, el cual tiene un promedio de {promedioAsus}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioIntel, promedioGigabyte)} que {Marca.EMarca.Gigabyte}, el cual tiene un promedio de {promedioGigabyte}gb");
            }

            if (marca == Marca.EMarca.Amd)
            {
                sb.AppendLine($"{marca} tiene un promedio de ram de {string.Format("{0:0.00}", promedioAmd)}gb, esto significa : ");
                sb.AppendLine($"{CalcularPorcentaje(promedioAmd, promedioMsi)} que {Marca.EMarca.Msi}, el cual tiene un promedio de {promedioMsi}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioAmd, promedioAsus)} que {Marca.EMarca.Asus}, el cual tiene un promedio de {promedioAsus}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioAmd, promedioGigabyte)} que {Marca.EMarca.Gigabyte}, el cual tiene un promedio de {promedioGigabyte}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioAmd, promedioIntel)} que {Marca.EMarca.Intel}, el cual tiene un promedio de {promedioIntel}gb");
            }


            return sb.ToString();
        }

        /// <summary>
        /// Calcula el promedio de ram de una lista de placas
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>

        private float CalcularPromedioRam(List<PlacaVideo> lista)
        {
            float ram = 0;


            foreach (var item in lista)
            {
                ram += item.CapacidadDeRam;
            }

            return ram / lista.Count;


        }

        /// <summary>
        /// Clacula el porcentaje entre dos valores
        /// </summary>
        /// <param name="promedio1"></param>
        /// <param name="promedio2"></param>
        /// <returns></returns>
        private string CalcularPorcentaje(float promedio1, float promedio2)
        {
            string retorno = "";
            if (promedio1 == promedio2)
            {
                retorno = $"Tienen la misma cantidad de ram";
            }
            else
            {
                if (promedio1 > promedio2)
                {
                    retorno = $"{string.Format("{0:0.00}", (((promedio1 * 100) / promedio2) - 100)).ToString()} % mas de ram";

                }
                else
                {
                    retorno = $"{string.Format("{0:0.00}", (((promedio2 * 100) / promedio1) - 100)).ToString()} % menos de ram";
                }

            }

            return retorno;
        }




        /// <summary>
        /// Analiza, segun  el tipo de memoria selecionado, el consumo promedio entre las distintas marcas de placas
        /// </summary>
        /// <param name="marca"></param>
        /// <returns></returns>

        public string AnalizarConsumoSegunTipoDeMemoria(PlacaVideo.ETipoMemoria tipo)
        {

            List<PlacaVideo> listaMsi = new List<PlacaVideo>();
            List<PlacaVideo> listaAsus = new List<PlacaVideo>();
            List<PlacaVideo> listaGigabyte = new List<PlacaVideo>();
            List<PlacaVideo> listaIntel = new List<PlacaVideo>();
            List<PlacaVideo> listaAmd = new List<PlacaVideo>();


            listaMsi = BuscarSegunPlaca(this.listaDePlacasACargarLado1, Marca.EMarca.Msi);
            listaAsus = BuscarSegunPlaca(this.listaDePlacasACargarLado1, Marca.EMarca.Asus);
            listaGigabyte = BuscarSegunPlaca(this.listaDePlacasACargarLado1, Marca.EMarca.Gigabyte);
            listaIntel = BuscarSegunPlaca(this.listaDePlacasACargarLado1, Marca.EMarca.Intel);
            listaAmd = BuscarSegunPlaca(this.listaDePlacasACargarLado1, Marca.EMarca.Amd);


            List<PlacaVideo> listaMsiSinAsignar = new List<PlacaVideo>();
            listaMsiSinAsignar = BuscarSegunTipoMemoria(listaMsi, PlacaVideo.ETipoMemoria.SinAsignar);

            List<PlacaVideo> listaMsiGDDR1 = new List<PlacaVideo>();
            listaMsiGDDR1 = BuscarSegunTipoMemoria(listaMsi, PlacaVideo.ETipoMemoria.GDDR1);

            List<PlacaVideo> listaMsiGDDR3 = new List<PlacaVideo>();
            listaMsiGDDR3 = BuscarSegunTipoMemoria(listaMsi, PlacaVideo.ETipoMemoria.GDDR3);

            List<PlacaVideo> listaMsiGDDR5 = new List<PlacaVideo>();
            listaMsiGDDR5 = BuscarSegunTipoMemoria(listaMsi, PlacaVideo.ETipoMemoria.GDDR5);



            List<PlacaVideo> listaAsusSinAsignar = new List<PlacaVideo>();
            listaAsusSinAsignar = BuscarSegunTipoMemoria(listaAsus, PlacaVideo.ETipoMemoria.SinAsignar);

            List<PlacaVideo> listaAsusGDDR1 = new List<PlacaVideo>();
            listaAsusGDDR1 = BuscarSegunTipoMemoria(listaAsus, PlacaVideo.ETipoMemoria.GDDR1);

            List<PlacaVideo> listaAsusGDDR3 = new List<PlacaVideo>();
            listaAsusGDDR3 = BuscarSegunTipoMemoria(listaAsus, PlacaVideo.ETipoMemoria.GDDR3);

            List<PlacaVideo> listaAsusGDDR5 = new List<PlacaVideo>();
            listaAsusGDDR5 = BuscarSegunTipoMemoria(listaAsus, PlacaVideo.ETipoMemoria.GDDR5);

            

            List<PlacaVideo> listaGigabyteSinAsignar = new List<PlacaVideo>();
            listaGigabyteSinAsignar = BuscarSegunTipoMemoria(listaGigabyte, PlacaVideo.ETipoMemoria.SinAsignar);

            List<PlacaVideo> listaGigabyteGDDR1 = new List<PlacaVideo>();
            listaGigabyteGDDR1 = BuscarSegunTipoMemoria(listaGigabyte, PlacaVideo.ETipoMemoria.GDDR1);

            List<PlacaVideo> listaGigabyteGDDR3 = new List<PlacaVideo>();
            listaGigabyteGDDR3 = BuscarSegunTipoMemoria(listaGigabyte, PlacaVideo.ETipoMemoria.GDDR3);

            List<PlacaVideo> listaGigabyteGDDR5 = new List<PlacaVideo>();
            listaGigabyteGDDR5 = BuscarSegunTipoMemoria(listaGigabyte, PlacaVideo.ETipoMemoria.GDDR5);


            List<PlacaVideo> listaIntelSinAsignar = new List<PlacaVideo>();
            listaIntelSinAsignar = BuscarSegunTipoMemoria(listaIntel, PlacaVideo.ETipoMemoria.SinAsignar);

            List<PlacaVideo> listaIntelGDDR1 = new List<PlacaVideo>();
            listaIntelGDDR1 = BuscarSegunTipoMemoria(listaIntel, PlacaVideo.ETipoMemoria.GDDR1);

            List<PlacaVideo> listaIntelGDDR3 = new List<PlacaVideo>();
            listaIntelGDDR3 = BuscarSegunTipoMemoria(listaIntel, PlacaVideo.ETipoMemoria.GDDR3);

            List<PlacaVideo> listaIntelGDDR5 = new List<PlacaVideo>();
            listaIntelGDDR5 = BuscarSegunTipoMemoria(listaIntel, PlacaVideo.ETipoMemoria.GDDR5);


            List<PlacaVideo> listaAmdSinAsignar = new List<PlacaVideo>();
            listaAmdSinAsignar = BuscarSegunTipoMemoria(listaAmd, PlacaVideo.ETipoMemoria.SinAsignar);

            List<PlacaVideo> listaAmdGDDR1 = new List<PlacaVideo>();
            listaAmdGDDR1 = BuscarSegunTipoMemoria(listaAmd, PlacaVideo.ETipoMemoria.GDDR1);

            List<PlacaVideo> listaAmdGDDR3 = new List<PlacaVideo>();
            listaAmdGDDR3 = BuscarSegunTipoMemoria(listaAmd, PlacaVideo.ETipoMemoria.GDDR3);

            List<PlacaVideo> listaAmdGDDR5 = new List<PlacaVideo>();
            listaAmdGDDR5 = BuscarSegunTipoMemoria(listaAmd, PlacaVideo.ETipoMemoria.GDDR5);



            float promedioTotalTipoSinAsignarListaMsi = CalcularPromedioConsumoDentroDeListaPlacas(listaMsiSinAsignar);
            float promedioTotalTipoGDDR1ListaMsi = CalcularPromedioConsumoDentroDeListaPlacas(listaMsiGDDR1);
            float promedioTotalTipoGDDR3ListaMsi = CalcularPromedioConsumoDentroDeListaPlacas(listaMsiGDDR3);
            float promedioTotalTipoGDDR5ListaMsi = CalcularPromedioConsumoDentroDeListaPlacas(listaMsiGDDR5);

            float promedioTotalTipoSinAsignarListaAsus = CalcularPromedioConsumoDentroDeListaPlacas(listaAsusSinAsignar);
            float promedioTotalTipoGDDR1ListaAsus = CalcularPromedioConsumoDentroDeListaPlacas(listaAsusGDDR1);
            float promedioTotalTipoGDDR3ListaAsus = CalcularPromedioConsumoDentroDeListaPlacas(listaAsusGDDR3);
            float promedioTotalTipoGDDR5ListaAsus = CalcularPromedioConsumoDentroDeListaPlacas(listaAsusGDDR5);

            float promedioTotalTipoSinAsignarListaGigabyte = CalcularPromedioConsumoDentroDeListaPlacas(listaGigabyteSinAsignar);
            float promedioTotalTipoGDDR1ListaGigabyte = CalcularPromedioConsumoDentroDeListaPlacas(listaGigabyteGDDR1);
            float promedioTotalTipoGDDR3ListaGigabyte = CalcularPromedioConsumoDentroDeListaPlacas(listaGigabyteGDDR3);
            float promedioTotalTipoGDDR5ListaGigabyte = CalcularPromedioConsumoDentroDeListaPlacas(listaGigabyteGDDR5);

            float promedioTotalTipoSinAsignarListaIntel = CalcularPromedioConsumoDentroDeListaPlacas(listaIntelSinAsignar);
            float promedioTotalTipoGDDR1ListaIntel = CalcularPromedioConsumoDentroDeListaPlacas(listaIntelGDDR1);
            float promedioTotalTipoGDDR3ListaIntel = CalcularPromedioConsumoDentroDeListaPlacas(listaIntelGDDR3);
            float promedioTotalTipoGDDR5ListaIntel = CalcularPromedioConsumoDentroDeListaPlacas(listaIntelGDDR5);

            float promedioTotalTipoSinAsignarListaAmd = CalcularPromedioConsumoDentroDeListaPlacas(listaAmdSinAsignar);
            float promedioTotalTipoGDDR1ListaAmd = CalcularPromedioConsumoDentroDeListaPlacas(listaAmdGDDR1);
            float promedioTotalTipoGDDR3ListaAmd = CalcularPromedioConsumoDentroDeListaPlacas(listaAmdGDDR3);
            float promedioTotalTipoGDDR5ListaAmd = CalcularPromedioConsumoDentroDeListaPlacas(listaAmdGDDR5);


            float promedioSinAsignar = CalcularPromedioConsumo(this.listaDePlacasACargarLado1, PlacaVideo.ETipoMemoria.SinAsignar);
            float promedioGDDR1 = CalcularPromedioConsumo(this.listaDePlacasACargarLado1, PlacaVideo.ETipoMemoria.GDDR1);
            float promedioGDDR3 = CalcularPromedioConsumo(this.listaDePlacasACargarLado1, PlacaVideo.ETipoMemoria.GDDR3);
            float promedioGDDR5 = CalcularPromedioConsumo(this.listaDePlacasACargarLado1, PlacaVideo.ETipoMemoria.GDDR5);
           


            StringBuilder sb = new StringBuilder();




            if (tipo == PlacaVideo.ETipoMemoria.SinAsignar)
            {
                sb.AppendLine($"Consumo promedio tipo memoria {tipo} es de: {string.Format("{0:0.00}", promedioSinAsignar)} W");
                sb.AppendLine($"{CalcularPorcentajeConsumo(promedioTotalTipoSinAsignarListaMsi, promedioSinAsignar)} en las placas tipo {Marca.EMarca.Msi}, cuyo promedio es de {string.Format("{0:0.00}", promedioTotalTipoSinAsignarListaMsi)}W");
                sb.AppendLine($"{CalcularPorcentajeConsumo(promedioTotalTipoSinAsignarListaAsus, promedioSinAsignar)} en las placas tipo {Marca.EMarca.Asus}, cuyo promedio es de {string.Format("{0:0.00}", promedioTotalTipoSinAsignarListaAsus)}W");
                sb.AppendLine($"{CalcularPorcentajeConsumo(promedioTotalTipoSinAsignarListaGigabyte, promedioSinAsignar)} en las placas tipo {Marca.EMarca.Gigabyte}, cuyo promedio es de {string.Format("{0:0.00}", promedioTotalTipoSinAsignarListaGigabyte)}W");
                sb.AppendLine($"{CalcularPorcentajeConsumo(promedioTotalTipoSinAsignarListaIntel, promedioSinAsignar)} en las placas tipo {Marca.EMarca.Intel}, cuyo promedio es de {string.Format("{0:0.00}", promedioTotalTipoSinAsignarListaIntel)}W ");
                sb.AppendLine($"{CalcularPorcentajeConsumo(promedioTotalTipoSinAsignarListaAmd, promedioSinAsignar)} en las placas tipo {Marca.EMarca.Amd}, cuyo promedio es de {string.Format("{0:0.00}", promedioTotalTipoSinAsignarListaAmd)}W");

            }
           
            if (tipo == PlacaVideo.ETipoMemoria.GDDR1)
            {
              
                sb.AppendLine($"Consumo promedio tipo memoria {tipo} es de: {string.Format("{0:0.00}", promedioGDDR1)} W");
                sb.AppendLine($"{CalcularPorcentajeConsumo(promedioTotalTipoGDDR1ListaMsi, promedioGDDR1)} en las placas tipo {Marca.EMarca.Msi}, cuyo promedio es de {string.Format("{0:0.00}", promedioTotalTipoGDDR1ListaMsi)}W");
                sb.AppendLine($"{CalcularPorcentajeConsumo(promedioTotalTipoGDDR1ListaAsus, promedioGDDR1)} en las placas tipo {Marca.EMarca.Asus}, cuyo promedio es de {string.Format("{0:0.00}", promedioTotalTipoGDDR1ListaAsus)}W");
                sb.AppendLine($"{CalcularPorcentajeConsumo(promedioTotalTipoGDDR1ListaGigabyte, promedioGDDR1)} en las placas tipo {Marca.EMarca.Gigabyte}, cuyo promedio es de {string.Format("{0:0.00}", promedioTotalTipoGDDR1ListaGigabyte)}W");
                sb.AppendLine($"{CalcularPorcentajeConsumo(promedioTotalTipoGDDR1ListaIntel, promedioGDDR1)} en las placas tipo {Marca.EMarca.Intel}, cuyo promedio es de {string.Format("{0:0.00}", promedioTotalTipoGDDR1ListaIntel)}W");
                sb.AppendLine($"{CalcularPorcentajeConsumo(promedioTotalTipoGDDR1ListaAmd, promedioGDDR1)} en las placas tipo {Marca.EMarca.Amd}, cuyo promedio es de {string.Format("{0:0.00}", promedioTotalTipoGDDR1ListaAmd)}W");
            }

            if (tipo == PlacaVideo.ETipoMemoria.GDDR3)
            {
                sb.AppendLine($"Consumo promedio tipo memoria {tipo} es de: {string.Format("{0:0.00}", promedioGDDR3)} W");
                sb.AppendLine($"{CalcularPorcentajeConsumo(promedioTotalTipoGDDR3ListaMsi, promedioGDDR3)} en las placas tipo {Marca.EMarca.Msi}, cuyo promedio es de {string.Format("{0:0.00}", promedioTotalTipoGDDR3ListaMsi)}W");
                sb.AppendLine($"{CalcularPorcentajeConsumo(promedioTotalTipoGDDR3ListaAsus, promedioGDDR3)} en las placas tipo {Marca.EMarca.Asus}, cuyo promedio es de {string.Format("{0:0.00}", promedioTotalTipoGDDR3ListaAsus)}W");
                sb.AppendLine($"{CalcularPorcentajeConsumo(promedioTotalTipoGDDR3ListaGigabyte, promedioGDDR3)} en las placas tipo {Marca.EMarca.Gigabyte}, cuyo promedio es de {string.Format("{0:0.00}", promedioTotalTipoGDDR3ListaGigabyte)}W");
                sb.AppendLine($"{CalcularPorcentajeConsumo(promedioTotalTipoGDDR3ListaIntel, promedioGDDR3)} en las placas tipo {Marca.EMarca.Intel}, cuyo promedio es de {string.Format("{0:0.00}", promedioTotalTipoGDDR3ListaIntel)}W");
                sb.AppendLine($"{CalcularPorcentajeConsumo(promedioTotalTipoGDDR3ListaAmd, promedioGDDR3)} en las placas tipo {Marca.EMarca.Amd}, cuyo promedio es de {string.Format("{0:0.00}", promedioTotalTipoGDDR3ListaAmd)}W");
            }

            if (tipo == PlacaVideo.ETipoMemoria.GDDR5)
            {
                sb.AppendLine($"Consumo promedio tipo memoria {tipo} es de: {string.Format("{0:0.00}", promedioGDDR5)} W");
                sb.AppendLine($"{CalcularPorcentajeConsumo(promedioTotalTipoGDDR5ListaMsi, promedioGDDR5)} en las placas tipo {Marca.EMarca.Msi}, cuyo promedio es de {string.Format("{0:0.00}", promedioTotalTipoGDDR5ListaMsi)}W");
                sb.AppendLine($"{CalcularPorcentajeConsumo(promedioTotalTipoGDDR5ListaAsus, promedioGDDR5)} en las placas tipo {Marca.EMarca.Asus}, cuyo promedio es de {string.Format("{0:0.00}", promedioTotalTipoGDDR5ListaAsus)}W");
                sb.AppendLine($"{CalcularPorcentajeConsumo(promedioTotalTipoGDDR5ListaGigabyte, promedioGDDR5)} en las placas tipo {Marca.EMarca.Gigabyte}, cuyo promedio es de {string.Format("{0:0.00}", promedioTotalTipoGDDR5ListaGigabyte)}W");
                sb.AppendLine($"{CalcularPorcentajeConsumo(promedioTotalTipoGDDR5ListaIntel, promedioGDDR5)} en las placas tipo {Marca.EMarca.Intel}, cuyo promedio es de {string.Format("{0:0.00}", promedioTotalTipoGDDR5ListaIntel)}W");
                sb.AppendLine($"{CalcularPorcentajeConsumo(promedioTotalTipoGDDR5ListaAmd, promedioGDDR5)} en las placas tipo {Marca.EMarca.Amd}, cuyo promedio es de {string.Format("{0:0.00}", promedioTotalTipoGDDR5ListaAmd)}W");
            }


            return sb.ToString();
        }




        /// <summary>
        /// obtiene una lista de placas segun el tipo de memoria dado
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="eTipo"></param>
        /// <returns></returns>
        public List<PlacaVideo> BuscarSegunTipoMemoria(List<PlacaVideo> lista, PlacaVideo.ETipoMemoria eTipo)
        {
            List<PlacaVideo> retorno = new List<PlacaVideo>();

            foreach (var item in lista)
            {
                if (item.TipoDeMemoria == eTipo)
                {
                    retorno.Add(item);
                }
            }

            return retorno;

        }




        /// <summary>
        /// Calcula el promedio de consumo segun el tipo indicado
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>

        private float CalcularPromedioConsumo(List<PlacaVideo> lista, PlacaVideo.ETipoMemoria eTipo)
        {
            float consumo = 0;
            float contadorEtipo = 0;

            foreach (var item in lista)
            {
                if (item.TipoDeMemoria == eTipo)
                {
                    consumo += item.Consumo;
                    contadorEtipo += 1;
                }

            }

            return consumo / contadorEtipo;


        }


        



        /// <summary>
        /// Calcula el promedio de ram de una lista de placas
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>

        private float CalcularPromedioConsumoDentroDeListaPlacas(List<PlacaVideo> listaPlacasSegunTipoYMarca)
        {
            float consumo = 0;
            float retorno = 0;

            foreach (var item in listaPlacasSegunTipoYMarca)
            {
                if(listaPlacasSegunTipoYMarca.Count>0)
                {
                    consumo += item.Consumo;
                }
               
            }
            if (listaPlacasSegunTipoYMarca.Count > 0)
            {
                retorno= consumo / listaPlacasSegunTipoYMarca.Count;
            }

            return retorno;



        }

        /// <summary>
        /// Clacula el porcentaje entre dos valores
        /// </summary>
        /// <param name="promedio1"></param>
        /// <param name="promedio2"></param>
        /// <returns></returns>


        private string CalcularPorcentajeConsumo(float promedioTotalSegunTipo, float promedioSegunTipoYMarca)
        {

                     string retorno = "";
            if (promedioTotalSegunTipo == promedioSegunTipoYMarca && (promedioTotalSegunTipo>0 && promedioSegunTipoYMarca>0))
            {
                retorno = $"Tiene el mismo consumo que el promedio";
            }
            else
            {

                if(promedioTotalSegunTipo==0|| promedioSegunTipoYMarca==0)
                {
                    retorno = "no tiene valores para analizar";
                }else if (promedioTotalSegunTipo > promedioSegunTipoYMarca && promedioSegunTipoYMarca > 0 && promedioTotalSegunTipo > 0)
                {
                    retorno = $"tiene {string.Format("{0:0.00}", (((promedioTotalSegunTipo * 100) / promedioSegunTipoYMarca) - 100)).ToString()} % mas de consumo";
                }
                else
                {
                    retorno = $"tiene {string.Format("{0:0.00}", (((promedioSegunTipoYMarca * 100) / promedioTotalSegunTipo) - 100)).ToString()} % menos de consumo";
                }

            }

            return retorno;
        }


    }
}
