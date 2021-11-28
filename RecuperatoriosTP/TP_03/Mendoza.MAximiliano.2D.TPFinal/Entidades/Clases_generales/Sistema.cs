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
                    listaAnalisis = this.listaDePlacasACargarLado1.FindAll((l) => l.CapacidadDeRam >= 16);
                    cantAnalisis = listaAnalisis.Count;
                    analisisFinal = (cantAnalisis * 100) / cantLista;

                    retorno = $"En el sistema hay {string.Format("{0:0.00}", analisisFinal)} %  de placas registradas con ram mayor o igual a 16";
                    break;
            }

            return retorno;
        }




        public bool algo(PlacaVideo p)
        {
            bool retorno = false;
            if (p.Consumo >= 1 && p.Consumo <= 25)
            {
                retorno = true;
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


                    //listaAnalisis = this.listaDePlacasACargarLado1.FindAll(algo);
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

            listaMsi = this.listaDePlacasACargarLado1.FindAll((l) => l.Marca.MarcaProducto == Marca.EMarca.Msi);
            listaAsus = this.listaDePlacasACargarLado1.FindAll((l) => l.Marca.MarcaProducto == Marca.EMarca.Asus);
            listaGigabyte = this.listaDePlacasACargarLado1.FindAll((l) => l.Marca.MarcaProducto == Marca.EMarca.Gigabyte);
            listaIntel = this.listaDePlacasACargarLado1.FindAll((l) => l.Marca.MarcaProducto == Marca.EMarca.Intel);
            listaAmd = this.listaDePlacasACargarLado1.FindAll((l) => l.Marca.MarcaProducto == Marca.EMarca.Amd);

            promedioMsi = CalcularPromedioRam(listaMsi);
            promedioAsus = CalcularPromedioRam(listaAsus);
            promedioGigabyte = CalcularPromedioRam(listaGigabyte);
            promedioIntel = CalcularPromedioRam(listaIntel);
            promedioAmd = CalcularPromedioRam(listaAmd);


            StringBuilder sb = new StringBuilder();



            if (marca == Marca.EMarca.Msi)
            {
                sb.AppendLine($"{marca} tiene un promedio de ram de {promedioMsi}gb, esto significa : ");
                sb.AppendLine($"{CalcularPorcentaje(promedioMsi, promedioAsus)} que {Marca.EMarca.Asus}, el cual tiene un promedio de {promedioAsus}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioMsi, promedioGigabyte)} que {Marca.EMarca.Gigabyte}, el cual tiene un promedio de {promedioGigabyte}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioMsi, promedioIntel)} que {Marca.EMarca.Intel}, el cual tiene un promedio de {promedioIntel}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioMsi, promedioAmd)} que {Marca.EMarca.Amd}, el cual tiene un promedio de {promedioAmd}gb");
            }

            if (marca == Marca.EMarca.Asus)
            {
                sb.AppendLine($"{marca} tiene un promedio de ram de {promedioAsus}gb, esto significa : ");
                sb.AppendLine($"{CalcularPorcentaje(promedioAsus, promedioGigabyte)} que {Marca.EMarca.Gigabyte}, el cual tiene un promedio de {promedioGigabyte}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioAsus, promedioIntel)} que {Marca.EMarca.Intel}, el cual tiene un promedio de {promedioIntel}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioAsus, promedioAmd)} que {Marca.EMarca.Amd}, el cual tiene un promedio de {promedioAmd}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioAsus, promedioMsi)} que {Marca.EMarca.Msi}, el cual tiene un promedio de {promedioMsi}gb");
            }

            if (marca == Marca.EMarca.Gigabyte)
            {
                sb.AppendLine($"{marca} tiene un promedio de ram de {promedioGigabyte}gb, esto significa : ");
                sb.AppendLine($"{CalcularPorcentaje(promedioGigabyte, promedioIntel)} que {Marca.EMarca.Intel}, el cual tiene un promedio de {promedioIntel}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioGigabyte, promedioAmd)} que {Marca.EMarca.Gigabyte}, el cual tiene un promedio de {promedioAmd}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioGigabyte, promedioMsi)} que {Marca.EMarca.Msi}, el cual tiene un promedio de {promedioMsi}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioGigabyte, promedioAsus)} que {Marca.EMarca.Asus}, el cual tiene un promedio de {promedioAsus}gb");
            }

            if (marca == Marca.EMarca.Intel)
            {
                sb.AppendLine($"{marca} tiene un promedio de ram de {promedioIntel}gb, esto significa : ");
                sb.AppendLine($"{CalcularPorcentaje(promedioIntel, promedioAmd)} que {Marca.EMarca.Amd}, el cual tiene un promedio de {promedioAmd}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioIntel, promedioMsi)} que {Marca.EMarca.Msi}, el cual tiene un promedio de {promedioMsi}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioIntel, promedioAsus)} que {Marca.EMarca.Asus}, el cual tiene un promedio de {promedioAsus}gb");
                sb.AppendLine($"{CalcularPorcentaje(promedioIntel, promedioGigabyte)} que {Marca.EMarca.Gigabyte}, el cual tiene un promedio de {promedioGigabyte}gb");
            }

            if (marca == Marca.EMarca.Amd)
            {
                sb.AppendLine($"{marca} tiene un promedio de ram de {promedioAmd}gb, esto significa : ");
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

            float promedioSinAsignarListaMsi = 0;
            float promedioGDDR1ListaMsi = 0;
            float promedioGDDR3ListaMsi = 0;
            float promedioGDDR5ListaMsi = 0;

            float promedioTotalTipoSinAsignarListaMsi = 0;
            float promedioTotalTipoGDDR1ListaMsi = 0;
            float promedioTotalTipoGDDR3ListaMsi = 0;
            float promedioTotalTipoGDDR5ListaMsi = 0;

            float promedioSinAsignarListaAsus = 0;
            float promedioGDDR1ListaAsus = 0;
            float promedioGDDR3ListaAsus = 0;
            float promedioGDDR5ListaAsus = 0;

            float promedioTotalTipoSinAsignarListaAsus = 0;
            float promedioTotalTipoGDDR1ListaAsus = 0;
            float promedioTotalTipoGDDR3ListaAsus = 0;
            float promedioTotalTipoGDDR5ListaAsus = 0;

            float promedioSinAsignarListaGigabyte = 0;
            float promedioGDDR1ListaGigabyte = 0;
            float promedioGDDR3ListaGigabyte = 0;
            float promedioGDDR5ListaGigabyte = 0;

            float promedioTotalTipoSinAsignarListaGigabyte = 0;
            float promedioTotalTipoGDDR1ListaGigabyte = 0;
            float promedioTotalTipoGDDR3ListaGigabyte = 0;
            float promedioTotalTipoGDDR5ListaGigabyte = 0;

            float promedioSinAsignarListaIntel = 0;
            float promedioGDDR1ListaIntel = 0;
            float promedioGDDR3ListaIntel = 0;
            float promedioGDDR5ListaIntel = 0;

            float promedioTotalTipoSinAsignarListaIntel = 0;
            float promedioTotalTipoGDDR1ListaIntel = 0;
            float promedioTotalTipoGDDR3ListaIntel = 0;
            float promedioTotalTipoGDDR5ListaIntel = 0;

            float promedioSinAsignarListaAmd = 0;
            float promedioGDDR1ListaAmd = 0;
            float promedioGDDR3ListaAmd = 0;
            float promedioGDDR5ListaAmd = 0;

            float promedioTotalTipoSinAsignarListaAmd = 0;
            float promedioTotalTipoGDDR1ListaAmd = 0;
            float promedioTotalTipoGDDR3ListaAmd = 0;
            float promedioTotalTipoGDDR5ListaAmd = 0;


            listaMsi = this.listaDePlacasACargarLado1.FindAll((l) => l.Marca.MarcaProducto == Marca.EMarca.Msi);
            listaAsus = this.listaDePlacasACargarLado1.FindAll((l) => l.Marca.MarcaProducto == Marca.EMarca.Asus);
            listaGigabyte = this.listaDePlacasACargarLado1.FindAll((l) => l.Marca.MarcaProducto == Marca.EMarca.Gigabyte);
            listaIntel = this.listaDePlacasACargarLado1.FindAll((l) => l.Marca.MarcaProducto == Marca.EMarca.Intel);
            listaAmd = this.listaDePlacasACargarLado1.FindAll((l) => l.Marca.MarcaProducto == Marca.EMarca.Amd);



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

            

            promedioTotalTipoSinAsignarListaMsi = CalcularPromedioConsumoDentroDeListaPlacas(listaMsiSinAsignar);
            promedioTotalTipoGDDR1ListaMsi = CalcularPromedioConsumoDentroDeListaPlacas(listaMsiGDDR1);
            promedioTotalTipoGDDR3ListaMsi = CalcularPromedioConsumoDentroDeListaPlacas(listaMsiGDDR3);
            promedioTotalTipoGDDR5ListaMsi = CalcularPromedioConsumoDentroDeListaPlacas(listaMsiGDDR5);


            promedioSinAsignarListaMsi = CalcularPromedioConsumoSegunTipo(this.listaDePlacasACargarLado1, listaMsiSinAsignar, PlacaVideo.ETipoMemoria.SinAsignar);
            promedioGDDR1ListaMsi = CalcularPromedioConsumoSegunTipo(this.listaDePlacasACargarLado1, listaMsiGDDR1, PlacaVideo.ETipoMemoria.GDDR1);
            promedioGDDR3ListaMsi = CalcularPromedioConsumoSegunTipo(this.listaDePlacasACargarLado1, listaMsiGDDR3, PlacaVideo.ETipoMemoria.GDDR3);
            promedioGDDR5ListaMsi = CalcularPromedioConsumoSegunTipo(this.listaDePlacasACargarLado1, listaMsiGDDR5, PlacaVideo.ETipoMemoria.GDDR5);

          

            promedioTotalTipoSinAsignarListaAsus = CalcularPromedioConsumoDentroDeListaPlacas(listaAsusSinAsignar);
            promedioTotalTipoGDDR1ListaAsus = CalcularPromedioConsumoDentroDeListaPlacas(listaAsusGDDR1);
            promedioTotalTipoGDDR3ListaAsus = CalcularPromedioConsumoDentroDeListaPlacas(listaAsusGDDR3);
            promedioTotalTipoGDDR5ListaAsus = CalcularPromedioConsumoDentroDeListaPlacas(listaAsusGDDR5);


            promedioSinAsignarListaAsus = CalcularPromedioConsumoSegunTipo(this.listaDePlacasACargarLado1, listaAsusSinAsignar, PlacaVideo.ETipoMemoria.SinAsignar);
            promedioGDDR1ListaAsus = CalcularPromedioConsumoSegunTipo(this.listaDePlacasACargarLado1, listaAsusGDDR1, PlacaVideo.ETipoMemoria.GDDR1);
            promedioGDDR3ListaAsus = CalcularPromedioConsumoSegunTipo(this.listaDePlacasACargarLado1, listaAsusGDDR3, PlacaVideo.ETipoMemoria.GDDR3);
            promedioGDDR5ListaAsus = CalcularPromedioConsumoSegunTipo(this.listaDePlacasACargarLado1, listaAsusGDDR5, PlacaVideo.ETipoMemoria.GDDR5);

            

            promedioTotalTipoSinAsignarListaGigabyte = CalcularPromedioConsumoDentroDeListaPlacas(listaGigabyteSinAsignar);
            promedioTotalTipoGDDR1ListaGigabyte = CalcularPromedioConsumoDentroDeListaPlacas(listaGigabyteGDDR1);
            promedioTotalTipoGDDR3ListaGigabyte = CalcularPromedioConsumoDentroDeListaPlacas(listaGigabyteGDDR3);
            promedioTotalTipoGDDR5ListaGigabyte = CalcularPromedioConsumoDentroDeListaPlacas(listaGigabyteGDDR5);


            promedioSinAsignarListaGigabyte = CalcularPromedioConsumoSegunTipo(this.listaDePlacasACargarLado1, listaGigabyteSinAsignar, PlacaVideo.ETipoMemoria.SinAsignar);
            promedioGDDR1ListaGigabyte = CalcularPromedioConsumoSegunTipo(this.listaDePlacasACargarLado1, listaGigabyteGDDR1, PlacaVideo.ETipoMemoria.GDDR1);
            promedioGDDR3ListaGigabyte = CalcularPromedioConsumoSegunTipo(this.listaDePlacasACargarLado1, listaGigabyteGDDR3, PlacaVideo.ETipoMemoria.GDDR3);
            promedioGDDR5ListaGigabyte = CalcularPromedioConsumoSegunTipo(this.listaDePlacasACargarLado1, listaGigabyteGDDR5, PlacaVideo.ETipoMemoria.GDDR5);
            

            promedioTotalTipoSinAsignarListaIntel = CalcularPromedioConsumoDentroDeListaPlacas(listaIntelSinAsignar);
            promedioTotalTipoGDDR1ListaIntel = CalcularPromedioConsumoDentroDeListaPlacas(listaIntelGDDR1);
            promedioTotalTipoGDDR3ListaIntel = CalcularPromedioConsumoDentroDeListaPlacas(listaIntelGDDR3);
            promedioTotalTipoGDDR5ListaIntel = CalcularPromedioConsumoDentroDeListaPlacas(listaIntelGDDR5);


            promedioSinAsignarListaIntel = CalcularPromedioConsumoSegunTipo(this.listaDePlacasACargarLado1, listaIntelSinAsignar, PlacaVideo.ETipoMemoria.SinAsignar);
            promedioGDDR1ListaIntel = CalcularPromedioConsumoSegunTipo(this.listaDePlacasACargarLado1, listaIntelGDDR1, PlacaVideo.ETipoMemoria.GDDR1);
            promedioGDDR3ListaIntel = CalcularPromedioConsumoSegunTipo(this.listaDePlacasACargarLado1, listaIntelGDDR3, PlacaVideo.ETipoMemoria.GDDR3);
            promedioGDDR5ListaIntel = CalcularPromedioConsumoSegunTipo(this.listaDePlacasACargarLado1, listaIntelGDDR5, PlacaVideo.ETipoMemoria.GDDR5);


           

            promedioTotalTipoSinAsignarListaAmd = CalcularPromedioConsumoDentroDeListaPlacas(listaAmdSinAsignar);
            promedioTotalTipoGDDR1ListaAmd = CalcularPromedioConsumoDentroDeListaPlacas(listaAmdGDDR1);
            promedioTotalTipoGDDR3ListaAmd = CalcularPromedioConsumoDentroDeListaPlacas(listaAmdGDDR3);
            promedioTotalTipoGDDR5ListaAmd = CalcularPromedioConsumoDentroDeListaPlacas(listaAmdGDDR5);


            promedioSinAsignarListaAmd = CalcularPromedioConsumoSegunTipo(this.listaDePlacasACargarLado1, listaAmdSinAsignar, PlacaVideo.ETipoMemoria.SinAsignar);
            promedioGDDR1ListaAmd = CalcularPromedioConsumoSegunTipo(this.listaDePlacasACargarLado1, listaAmdGDDR1, PlacaVideo.ETipoMemoria.GDDR1);
            promedioGDDR3ListaAmd = CalcularPromedioConsumoSegunTipo(this.listaDePlacasACargarLado1, listaAmdGDDR3, PlacaVideo.ETipoMemoria.GDDR3);
            promedioGDDR5ListaAmd = CalcularPromedioConsumoSegunTipo(this.listaDePlacasACargarLado1, listaAmdGDDR5, PlacaVideo.ETipoMemoria.GDDR5);


            StringBuilder sb = new StringBuilder();




            if (tipo == PlacaVideo.ETipoMemoria.SinAsignar)
            {
                sb.AppendLine($"Consumo promedio tipo memoria {tipo} es de: {string.Format("{0:0.00}", CalcularPromedioConsumo(this.listaDePlacasACargarLado1, tipo))} W");
                sb.AppendLine($"El tipo de memoria {tipo} {CalcularPorcentajeConsumo(promedioTotalTipoSinAsignarListaMsi, promedioSinAsignarListaMsi)} en las placas tipo {Marca.EMarca.Msi}");
                sb.AppendLine($"El tipo de memoria {tipo} {CalcularPorcentajeConsumo(promedioTotalTipoSinAsignarListaAsus, promedioSinAsignarListaAsus)} en las placas tipo {Marca.EMarca.Asus}");
                sb.AppendLine($"El tipo de memoria {tipo} {CalcularPorcentajeConsumo(promedioTotalTipoSinAsignarListaGigabyte, promedioSinAsignarListaGigabyte)} en las placas tipo {Marca.EMarca.Gigabyte}");
                sb.AppendLine($"El tipo de memoria {tipo} {CalcularPorcentajeConsumo(promedioTotalTipoSinAsignarListaIntel, promedioSinAsignarListaIntel)} en las placas tipo {Marca.EMarca.Intel}");
                sb.AppendLine($"El tipo de memoria {tipo} {CalcularPorcentajeConsumo(promedioTotalTipoSinAsignarListaAmd, promedioSinAsignarListaAmd)} en las placas tipo {Marca.EMarca.Amd}");

            }
           
            if (tipo == PlacaVideo.ETipoMemoria.GDDR1)
            {
                sb.AppendLine($"Consumo promedio tipo memoria {tipo} es de: {string.Format("{0:0.00}", CalcularPromedioConsumo(this.listaDePlacasACargarLado1, tipo))} W");
                sb.AppendLine($"El tipo de memoria {tipo} {CalcularPorcentajeConsumo(promedioTotalTipoGDDR1ListaMsi, promedioGDDR1ListaMsi)} en las placas tipo {Marca.EMarca.Msi}");
                sb.AppendLine($"El tipo de memoria {tipo} {CalcularPorcentajeConsumo(promedioTotalTipoGDDR1ListaAsus, promedioGDDR1ListaAsus)} en las placas tipo {Marca.EMarca.Asus}");
                sb.AppendLine($"El tipo de memoria {tipo} {CalcularPorcentajeConsumo(promedioTotalTipoGDDR1ListaGigabyte, promedioGDDR1ListaGigabyte)} en las placas tipo {Marca.EMarca.Gigabyte}");
                sb.AppendLine($"El tipo de memoria {tipo} {CalcularPorcentajeConsumo(promedioTotalTipoGDDR1ListaIntel, promedioGDDR1ListaIntel)} en las placas tipo {Marca.EMarca.Intel}");
                sb.AppendLine($"El tipo de memoria {tipo} {CalcularPorcentajeConsumo(promedioTotalTipoGDDR1ListaAmd, promedioGDDR1ListaAmd)} en las placas tipo {Marca.EMarca.Amd}");
            }

            if (tipo == PlacaVideo.ETipoMemoria.GDDR3)
            {
                sb.AppendLine($"Consumo promedio tipo memoria {tipo} es de: {string.Format("{0:0.00}", CalcularPromedioConsumo(this.listaDePlacasACargarLado1, tipo))} W");
                sb.AppendLine($"El tipo de memoria {tipo} {CalcularPorcentajeConsumo(promedioTotalTipoGDDR3ListaMsi, promedioGDDR3ListaMsi)} en las placas tipo {Marca.EMarca.Msi}");
                sb.AppendLine($"El tipo de memoria {tipo} {CalcularPorcentajeConsumo(promedioTotalTipoGDDR3ListaAsus, promedioGDDR3ListaAsus)} en las placas tipo {Marca.EMarca.Asus}");
                sb.AppendLine($"El tipo de memoria {tipo} {CalcularPorcentajeConsumo(promedioTotalTipoGDDR3ListaGigabyte, promedioGDDR3ListaGigabyte)} en las placas tipo {Marca.EMarca.Gigabyte}");
                sb.AppendLine($"El tipo de memoria {tipo} {CalcularPorcentajeConsumo(promedioTotalTipoGDDR3ListaIntel, promedioGDDR3ListaIntel)} en las placas tipo {Marca.EMarca.Intel}");
                sb.AppendLine($"El tipo de memoria {tipo} {CalcularPorcentajeConsumo(promedioTotalTipoGDDR3ListaAmd, promedioGDDR3ListaAmd)} en las placas tipo {Marca.EMarca.Amd}");
            }

            if (tipo == PlacaVideo.ETipoMemoria.GDDR5)
            {
                sb.AppendLine($"Consumo promedio tipo memoria {tipo} es de: {string.Format("{0:0.00}", CalcularPromedioConsumo(this.listaDePlacasACargarLado1, tipo))} W");
                sb.AppendLine($"El tipo de memoria {tipo} {CalcularPorcentajeConsumo(promedioTotalTipoGDDR5ListaMsi, promedioGDDR5ListaMsi)} en las placas tipo {Marca.EMarca.Msi}");
                sb.AppendLine($"El tipo de memoria {tipo} {CalcularPorcentajeConsumo(promedioTotalTipoGDDR5ListaAsus, promedioGDDR5ListaAsus)} en las placas tipo {Marca.EMarca.Asus}");
                sb.AppendLine($"El tipo de memoria {tipo} {CalcularPorcentajeConsumo(promedioTotalTipoGDDR5ListaGigabyte, promedioGDDR5ListaGigabyte)} en las placas tipo {Marca.EMarca.Gigabyte}");
                sb.AppendLine($"El tipo de memoria {tipo} {CalcularPorcentajeConsumo(promedioTotalTipoGDDR5ListaIntel, promedioGDDR5ListaIntel)} en las placas tipo {Marca.EMarca.Intel}");
                sb.AppendLine($"El tipo de memoria {tipo} {CalcularPorcentajeConsumo(promedioTotalTipoGDDR5ListaAmd, promedioGDDR5ListaAmd)} en las placas tipo {Marca.EMarca.Amd}");
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
        /// 
        private float CalcularPromedioConsumoSegunTipo(List<PlacaVideo> listaPlacasLado1, List<PlacaVideo> listaPlacasSegunTipo, PlacaVideo.ETipoMemoria eTipo)
        {
            float consumo = CalcularPromedioConsumo(listaPlacasLado1, eTipo);
            float retorno = 0;

            if (listaPlacasSegunTipo.Count > 0)
            {
                retorno = consumo / listaPlacasSegunTipo.Count;
            }

            return retorno;

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
