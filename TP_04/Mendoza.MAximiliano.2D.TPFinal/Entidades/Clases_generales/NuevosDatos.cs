using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases_generales
{
   public class NuevosDatos
    {
        private string dato;
        private int valor;

        /// <summary>
        /// Devuelve el dato
        /// </summary>
        public string Dato
        {
            get { return this.dato; }
            set { this.dato = value; }
        }

        /// <summary>
        /// Devuelve el valor
        /// </summary>
        public int Valor
        {
            get { return this.valor; }
            set { this.valor = value; }
        }

        /// <summary>
        ///]Constructor sin parametros
        /// </summary>
        public NuevosDatos()
        {

        }
        /// <summary>
        /// Constructor que instancia los nuevos datos
        /// </summary>
        /// <param name="dato"></param>
        /// <param name="valor"></param>
        public NuevosDatos(string dato,int valor)
        :this()
        {
            this.dato = dato;
            this.valor = valor;
        }

        /// <summary>
        /// Metodo que muestra la info de NuevosDatos
        /// </summary>
        /// <returns></returns>
        public string MostrarNuevosDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Dato}: {this.Valor}");
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga tostring devuelve MostrarNuevosDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarNuevosDatos();
        }


        /// <summary>
        /// Verifica que dos datos son iguales si tienen mismo dato 
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static bool operator==(NuevosDatos n1, NuevosDatos n2)
        {
            return (n1.dato == n2.dato );
        }

        /// <summary>
        /// veo si dos nuevos datos no son iguales en la lista
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static bool operator !=(NuevosDatos n1, NuevosDatos n2)
        {
            return !(n1 == n2);
        }
    }
}
