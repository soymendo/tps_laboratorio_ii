using Entidades.Clases_generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases_especializadas
{
   public class Memoria : Comparar
    {

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Memoria()
        {

        }
        /// <summary>
        /// Constructor que recibe, p1, p2
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public Memoria(PlacaVideo p1,PlacaVideo p2)
        :base(p1,p2)
        {

        }
        /// <summary>
        /// Muestra la comparacion de Memoria
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public override string Mostrar(PlacaVideo p1,PlacaVideo p2)
        {
            return this.CompararMemoria(p1, p2);
        }

        /// <summary>
        /// Devuelve lo que compara
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Comparar Memoria";
        }

    }
}
