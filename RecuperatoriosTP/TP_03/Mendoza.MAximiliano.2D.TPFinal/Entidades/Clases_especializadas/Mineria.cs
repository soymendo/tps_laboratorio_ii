using Entidades.Clases_generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases_especializadas
{
   public class Mineria: Comparar
    {

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Mineria()
        {

        }

        /// <summary>
        /// Constructor que recibe, p1, p2
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public Mineria(PlacaVideo p1, PlacaVideo p2)
        : base(p1, p2)
        {

        }

        /// <summary>
        /// Muestra la comparacion de Mineria
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public override string Mostrar(PlacaVideo p1, PlacaVideo p2)
        {
            return this.CompararMineria(p1, p2);
        }

        /// <summary>
        /// Devuelve lo que compara
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Comparar Mineria";
        }
    }
}
