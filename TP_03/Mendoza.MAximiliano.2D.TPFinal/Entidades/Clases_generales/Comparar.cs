using Entidades.Clases_especializadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases_generales
{
    public abstract class Comparar
    {
        private PlacaVideo p1;
        private PlacaVideo p2;
        private string dato;

        public PlacaVideo P1
        {
            get { return this.p1; }
            set { this.p1 = value; }
        }

        public PlacaVideo P2
        {
            get { return this.p2; }
            set { this.p2 = value; }
        }

        public string Dato
        {
            get { return this.dato; }
            set { this.dato = value; }
        }

        public Comparar()
        {
            this.p1 = new PlacaVideo();
            this.p2 = new PlacaVideo();
        }


        public Comparar(PlacaVideo p1,PlacaVideo p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
        public Comparar(PlacaVideo p1, PlacaVideo p2, string dato)
            :this(p1,p2)
        {
           
        }

        /// <summary>
        /// Mostrara la comparacion en las clases derivadas
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public virtual string Mostrar(PlacaVideo p1, PlacaVideo p2)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(CompararMemoria(p1, p2));
            sb.AppendLine(CompararDatosGenerales(p1, p2));
            sb.AppendLine(CompararMineria(p1, p2));
            return sb.ToString();
        }

        public virtual string Mostrar(PlacaVideo p1, PlacaVideo p2,string dato)
        {
            return "";
        }
        /// <summary>
        /// compara
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <param name="aux1"></param>
        /// <param name="aux2"></param>
        /// <param name="nombreP1"></param>
        /// <param name="nombreP2"></param>
        /// <returns></returns>
        public string CompararBase(float n1, float n2, string aux1, string aux2, string nombreP1, string nombreP2)
        {
            StringBuilder sb = new StringBuilder();
            if (n1 == n2)
            {
                sb.Append($"{aux2}");
            }
            else if (n1 > n2)
            {
                sb.Append($"{nombreP1} {aux1}");
            }
            else
            { sb.Append($"{nombreP2} {aux1}"); }
            return sb.ToString();
        }


        /// <summary>
        /// Compara el tipo de memoria de la placa
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>

        public string CompararTipoDeMemoria(PlacaVideo p1, PlacaVideo p2)
        {
            string aux1 = "tiene el tipo de memoria es mas actual";
            string aux4 = "En memoria son iguales";
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(CompararBase((int)p1.TipoDeMemoria, (int)p2.TipoDeMemoria, aux1, aux4, p1.Nombre, p2.Nombre));
            return sb.ToString();
        }


        /// <summary>
        /// Compara la capacidad de ram de dos placas
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public string CompararCapacidadDeRam(PlacaVideo p1, PlacaVideo p2)
        {
            //Comparar CompararLaCapacidadDeRam = new Comparar(p1,p2);

            string aux1 = "tiene mas capacidad de ram";
            string aux4 = "En Ram son iguales";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(CompararBase(p1.CapacidadDeRam, p2.CapacidadDeRam, aux1, aux4, p1.Nombre, p2.Nombre));
            return sb.ToString();

        }

        /// <summary>
        /// Compara la frecuencia de dos placas
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public string CompararFrecuencia(PlacaVideo p1, PlacaVideo p2)
        {
            string aux1 = "tiene mas frecuencia de memoria";
            string aux4 = "En frecuencia son iguales";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(CompararBase(p1.FrecuenciaDeMemoria, p2.FrecuenciaDeMemoria, aux1, aux4, p1.Nombre, p2.Nombre));
            return sb.ToString();

        }



        /// <summary>
        /// cOMPARA LOS DATOS CORRESPONDIENTE A LA MEMORIA
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>

        public string CompararMemoria(PlacaVideo p1, PlacaVideo p2)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"****Comparacion en Memoria entre {p1} y {p2}****\n");
            sb.AppendLine(CompararTipoDeMemoria(p1, p2));
            sb.AppendLine(CompararCapacidadDeRam(p1, p2));
            sb.AppendLine(CompararFrecuencia(p1, p2));

            return sb.ToString();
        }




        /// <summary>
        /// Compara el consume de las placas
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>

        public string CompararConsumo(PlacaVideo p1, PlacaVideo p2)
        {
            string aux1 = "tiene mas Consumo";
            string aux2 = "En consumo son iguales";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(CompararBase(p1.Consumo, p2.Consumo, aux1, aux2, p1.Nombre, p2.Nombre));
            return sb.ToString();
        }


        /// <summary>
        /// Compara la longitud de las placas
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public string CompararLongitud(PlacaVideo p1, PlacaVideo p2)
        {
            string aux1 = "tiene mas Longitud";
            string aux2 = "En longitud son iguales";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(CompararBase(p1.Longitud, p2.Longitud, aux1, aux2, p1.Nombre, p2.Nombre));
            return sb.ToString();
        }

        /// <summary>
        /// Compara la interfaz de placas
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public string CompararInterfaz(PlacaVideo p1, PlacaVideo p2)
        {
            string aux1 = "tiene mas Interfaz";
            string aux2 = "son iguales";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(CompararBase(p1.Interfaz, p2.Interfaz, aux1, aux2, p1.Nombre, p2.Nombre));
            return sb.ToString();
        }

        /// <summary>
        /// COMPARA LOS DATOS Generales
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public string CompararDatosGenerales(PlacaVideo p1, PlacaVideo p2)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"****Comparacion en Datos generales entre {p1} y {p2}****\n");
            sb.AppendLine(CompararConsumo(p1, p2));
            sb.AppendLine(CompararLongitud(p1, p2));
            sb.AppendLine(CompararInterfaz(p1, p2));

            return sb.ToString();
        }


        /// <summary>
        /// Compara el rendimiento en cuanto a mineria bitcoin
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public string CompararMineriaBit(PlacaVideo p1, PlacaVideo p2)
        {
            string aux1 = "tiene mas rendimiento en Bitcoin";
            string aux2 = "son iguales";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(CompararBase(p1.MineriaBitcoin, p2.MineriaBitcoin, aux1, aux2, p1.Nombre, p2.Nombre));
            return sb.ToString();
        }


        /// <summary>
        /// Compara el rendimiento en cuanto a mineria ethereum
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public string CompararMineriaEthereum(PlacaVideo p1, PlacaVideo p2)
        {
            string aux1 = "tiene mas rendimiento en Ethereum";
            string aux2 = "son iguales";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(CompararBase(p1.MineriaEthereum, p2.MineriaEthereum, aux1, aux2, p1.Nombre, p2.Nombre));

            return sb.ToString();
        }

        /// <summary>
        /// COMPARA LOS DATOS en cuanto a mineria
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public string CompararMineria(PlacaVideo p1, PlacaVideo p2)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"****Comparacion en Mineria entre {p1} y {p2}****\n");
            sb.AppendLine(CompararMineriaBit(p1, p2));
            sb.AppendLine(CompararMineriaEthereum(p1, p2));

            return sb.ToString();
        }


        /// <summary>
        /// Compara datos en la lista de nuevosDatos
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        public string CompararDatosNuevos(PlacaVideo p1, PlacaVideo p2, string dato)
        {

            string aux1 = "tiene mas";
            string aux2 = "son iguales";

            int indiceP1 = -1;
            int indiceP2 = -1;


            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"****Comparacion en {dato}  entre {p1} y {p2}**** \n");
            foreach (NuevosDatos item in p1.NuevosDatos)
            {
                if (item.Dato == dato)
                {
                    indiceP1 = p1.NuevosDatos.IndexOf(item);
                }
            }

            foreach (NuevosDatos item in p2.NuevosDatos)
            {
                if (item.Dato == dato)
                {
                    indiceP2 = p2.NuevosDatos.IndexOf(item);
                }
            }


            if (indiceP1 >= 0 && indiceP2 >= 0)
            {
                if (p1.NuevosDatos[indiceP1].Valor == p2.NuevosDatos[indiceP2].Valor)
                {
                    sb.AppendLine($"{dato} {aux2}  ");
                }
                else if (p1.NuevosDatos[indiceP1].Valor > p2.NuevosDatos[indiceP2].Valor)
                {
                    sb.AppendLine($"{p1.Nombre} {aux1} {dato}");
                }
                else
                {
                    sb.AppendLine($"{p2.Nombre} {aux1} {dato}");
                }
            }


            else if (indiceP1 == -1 && indiceP2 == -1)
            {
                sb.AppendLine("Sin datos");
            }
            else if (indiceP1 < 0)
            {
                sb.AppendLine($"{p2.Nombre} {aux1} {dato}");
            }
            else if (indiceP2 < 0)
            {
                sb.AppendLine($"{p1.Nombre} {aux1} {dato}");
            }



            return sb.ToString();
        }


    }
}
