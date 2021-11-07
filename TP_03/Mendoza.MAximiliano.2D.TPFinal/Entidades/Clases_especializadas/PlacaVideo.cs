using Entidades.Clases_generales;
using Entidades.Exepciones;
using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades.Clases_especializadas
{
    public class PlacaVideo: Hardware, IArchvoXml
    {
       
        public enum ETipoMemoria
        {
            SinAsignar, GDDR1, GDDR3, GDDR5
        }

        private ETipoMemoria tipoDeMemoria;
        private int capacidadDeRam ;
        private int frecuenciaDeMemoria;

        private int consumo;
        private int longitud;
        private float interfazPci;

        private float mineriaEnBitcoin;
        private float mineriaEnEthereum;

        /// <summary>
        /// Devuelve/Escribe TipoDeMemoria
        /// </summary>
        public ETipoMemoria TipoDeMemoria
        {
            get { return this.tipoDeMemoria; }
            set { tipoDeMemoria = value; }
        }
        /// <summary>
        /// Devuelve/Escribe CapacidadDeRam
        /// </summary>
        public int CapacidadDeRam
        {
            get { return this.capacidadDeRam; }
            set { this.capacidadDeRam = value; }
        }
        /// <summary>
        /// Devuelve/Escribe FrecuenciaDeMemoria
        /// </summary>
        public int FrecuenciaDeMemoria
        {
             get { return this.frecuenciaDeMemoria; }
             set {this.frecuenciaDeMemoria = value; }
        }

        /// <summary>
        /// Devuelve/escribe el consumo
        /// </summary>
        public int Consumo
        {
            get { return this.consumo; }
            set { this.consumo=value; }
        }

        /// <summary>
        /// Devuelve/escribe la longitud
        /// </summary>
        public int Longitud
        {
            get { return this.longitud; }
            set { this.longitud = value; }
        }

        /// <summary>
        /// Devuelve/escribe la interfaz Pci
        /// </summary>
        public float Interfaz
        {
            get { return this.interfazPci; }
            set { this.interfazPci = value; }
        }


        /// <summary>
        /// Devuelve/escrbe la mineria en bit por seg
        /// </summary>
        public float MineriaBitcoin
        {
            get { return this.mineriaEnBitcoin; }
            set { this.mineriaEnBitcoin = value; }
        }

        /// <summary>
        /// Devuelve/escrbe la mineria en Ethereum por seg
        /// </summary>
        public float MineriaEthereum
        {
            get { return this.mineriaEnEthereum; }
            set { this.mineriaEnEthereum = value; }
        }

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public PlacaVideo()
        {

        }

        /// <summary>
        /// Constructor para asignarle marca,nombre,memoria
        /// </summary>
        public PlacaVideo(string nombre, Marca.EMarca marca)
        :base(nombre,marca)
        {
          
        }


        /// <summary>
        /// Metodo que devuelve la informacion del objeto PlacaVideo
        /// </summary>
        /// <returns></returns>
        public override string Informar()
        {
          
            StringBuilder sb = new StringBuilder();
            sb.Append($"{base.ToString()}");
            sb.Append(InformarMemoria());
            sb.Append(InformarDatosGenerales());
            sb.Append(InformarMineria());

            foreach (NuevosDatos item in this.NuevosDatos)
            {
                sb.Append($"{item.ToString()}");
            }

            return sb.ToString();
           
        }



        public string Informar(string dato)
        {
           

            StringBuilder sb = new StringBuilder();
            switch (dato)
            {
                case "Comparar Memoria": sb.Append(InformarMemoria());
                    break;
                case "Comparar Datos Generales": sb.Append(InformarDatosGenerales());
                    break;
                case "Comparar Mineria": sb.Append(InformarMineria());
                    break;
               

            }
            sb.Append(BuscarValoresDato(dato));

            return sb.ToString();
        }

        /// <summary>
        /// busca los valores del dato pasado como parametro
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public string BuscarValoresDato(string dato)
        {
            string n1 = dato;
            string n2 = n1.Substring(9,n1.Length - 9);

            StringBuilder sb = new StringBuilder();
            foreach (var item in this.NuevosDatos)
            {
                if(item.Dato==n2)
                {
                    sb.Append($"{item.ToString()}");
                   
                }
            }
            return sb.ToString();
        }
      /// <summary>
      /// DEvuelve la info general con respecto a la memoria de la placa
      /// </summary>
      /// <returns></returns>

        public string InformarMemoria()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Tipo de memoria: {this.TipoDeMemoria}");
            if(this.CapacidadDeRam == 0) 
            {
                sb.AppendLine($"Ram: sin asignar");
            }
            else
            {
                sb.AppendLine($"Capacidad de Ram: {this.CapacidadDeRam} GB");
            }
            
            if(this.FrecuenciaDeMemoria==0)
            {
                sb.AppendLine($"Frecuencia de memoria: sin asignar");
            }
            else
            {
                sb.AppendLine($"Frecuencia de memoria: {this.FrecuenciaDeMemoria}");
            }

          
            return sb.ToString();
        }

        /// <summary>
        /// Informa los datos generales d ela plca
        /// </summary>
        /// <returns></returns>
        public string InformarDatosGenerales()
        {
            StringBuilder sb = new StringBuilder();
            
            if (this.Consumo == 0)
            {
                sb.AppendLine($"Consumo: sin asignar");
            }
            else
            {
                sb.AppendLine($"Consumo: {this.Consumo} w");
            }

            if (this.Longitud == 0)
            {
                sb.AppendLine($"Longitud: sin asignar");
            }
            else
            {
                sb.AppendLine($"Longitud: {this.Longitud}mm");
            }

            if(this.Interfaz==0)
            {
                sb.AppendLine($"Interfaz sin asignar");
            }
            else
            {
                sb.AppendLine($"Interfaz: {this.Interfaz}");
            }


            return sb.ToString();
        }



        public string InformarMineria()
        {
            StringBuilder sb = new StringBuilder();

            if (this.MineriaBitcoin == 0)
            {
                sb.AppendLine($"Mineria bitcoin: sin asignar");
            }
            else
            {
                sb.AppendLine($"Mineria en bitcoin: {this.MineriaBitcoin} /24hs");
            }

            if (this.MineriaEthereum == 0)
            {
                sb.AppendLine($"Mineria en Ethereum: sin asignar");
            }
            else
            {
                sb.AppendLine($"Mineria en Ethereum: {this.MineriaEthereum} /24hs");
            }


            return sb.ToString();
        }

        /// <summary>
        /// usado en el list del form
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //return this.Informar();
            return this.Nombre; //para el combobox
        }


        /// <summary>
        /// Serializa a xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruta"></param>
        /// <param name="objeto"></param>
        public void Guardar(string ruta)
        {
            
            using (StreamWriter streamWriter = new StreamWriter(ruta + $".\\{this.Nombre}.xml"))
            {
              
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlacaVideo));
                xmlSerializer.Serialize(streamWriter,this);
            }
             
        }

        public T Leer<T>(string ruta) where T : class
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(ruta))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    T objeto = xmlSerializer.Deserialize(streamReader) as T;
                    return objeto;
                }
            }
            catch (Exception )
            {

                throw new NoAgregaDatosException("Archivo no valido");
            }
          
        }

       


        /// <summary>
        /// compara dos objetos usando el equas de Hardware
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <returns></returns>
        public static bool operator==(PlacaVideo p1,PlacaVideo p2)
        {
            return ( Hardware.Equals(p1, p2) );
        }

        public static bool operator !=(PlacaVideo p1, PlacaVideo p2)
        {
            return !(p1==p2);
        }

    }
}
