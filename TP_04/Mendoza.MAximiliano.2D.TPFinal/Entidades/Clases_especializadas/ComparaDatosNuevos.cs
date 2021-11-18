using Entidades.Clases_generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases_especializadas
{
   
    public class ComparaDatosNuevos : Comparar
    {
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public ComparaDatosNuevos()
        {

        }

        public ComparaDatosNuevos(string dato)
        {

        }


        public ComparaDatosNuevos(PlacaVideo p1, PlacaVideo p2)
        :base(p1,p2)
        {

        }
        /// <summary>
        /// Constructor que recibe, p1, p2
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public ComparaDatosNuevos(PlacaVideo p1, PlacaVideo p2,string dato)
        : base(p1, p2,dato)
        {

        }

        /// <summary>
        /// Muestra la comparacion de los datos nuevos
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        //public override string Mostrar(PlacaVideo p1, PlacaVideo p2,string dato)
        //{
        //     return this.CompararDatosNuevos(p1,p2,dato);

        //}
        public override string Mostrar(PlacaVideo p1, PlacaVideo p2)
        {
            return this.CompararDatosNuevos(p1, p2, base.Dato);

        }


        /// <summary>
        /// Devuelve lo que compara
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
             return $"Comparar {this.Dato}";
          
        }
    }
}
