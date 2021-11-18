using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases_generales
{
    public sealed class Marca
    {

        private EMarca marca;

        /// <summary>
        /// Enum devuelve la marca del producto
        /// </summary>
        public EMarca MarcaProducto
        {
            get
            {
                return this.marca;
            }
            set
            {
                this.marca = value;
            }
        }

        /// <summary>
        /// Enumerado Marca
        /// </summary>
        public enum EMarca 
        {
            Msi,Asus,Gigabyte,Intel,Amd
        }

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Marca()
        {

        }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="marca"></param>
        public Marca(EMarca marca)
        {
            this.marca = marca;
        }



        /// <summary>
        /// Devuelve la informacion de la marca
        /// a traves de sus propiedades
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Marca: {this.MarcaProducto}");
            return sb.ToString();
        }

        /// <summary>
        ///Compara si dos marcas son iguales
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static bool operator==(Marca m1,Marca m2)
        {
            return (m1.MarcaProducto == m2.MarcaProducto);
        }


        public static bool operator !=(Marca m1, Marca m2)
        {
            return !(m1 == m2);
        }

   }
}
