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
    public class Sistema:IArchivoJson
       
    {
        private int capacidadDatosAAlmacenar;

        private DatosGeneric<PlacaVideo> datosOriginales;

        private List<PlacaVideo> listaDePlacasACargarLado1;
        private List<PlacaVideo> listaDePlacasACargarLado2;
        private List<Comparar> comparaciones;//carag en combobox

        /// <summary>
        /// Contructor, inicializa la lista
        /// </summary>
        public Sistema()
        {
            this.datosOriginales = new DatosGeneric<PlacaVideo>();
            this.listaDePlacasACargarLado1 = new List<PlacaVideo>();
            this.listaDePlacasACargarLado2 = new List<PlacaVideo>();
            this.comparaciones = new List<Comparar>()
            {
                new Memoria(new PlacaVideo (),new PlacaVideo ()),
                new DatosGenerales(new PlacaVideo (),new PlacaVideo ()),
                new Mineria(new PlacaVideo (),new PlacaVideo ()),
                
            };
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
        public  bool VerificarIngresoDeDatosQueNoSeRepita(ComparaDatosNuevos c)
        {
            bool retorno = false;
            foreach (var item in this.Comparaciones)
            {
                if(item.ToString()==c.ToString())
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public void Guardar(string ruta,string contenido)
        {
            using (StreamWriter streamWriter = new StreamWriter(ruta))
            {
                string json = JsonSerializer.Serialize(contenido);
                streamWriter.Write(json);
            }
        }

       
    }
}
