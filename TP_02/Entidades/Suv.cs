using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {


        #region  "Propiedades"
        /// <summary>
        /// SUV son 'Grande'
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
            set
            {
                this.Tamanio = value;
            }
        }

        #endregion


        #region "Constructores"
        /// <summary>
        /// Único constructor de instancia.
        /// </summary>
        /// <param name="chasis">Chasis del vehículo</param>
        /// <param name="marca">Marca del vehículo</param>
        /// <param name="color">Color del vehículo</param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
         : base(chasis, marca, color)
        {
        }
        #endregion


        #region "Metodos"
        /// <summary>
        /// Muestra la informacion de la clase junto con la de la clase base
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar()); ;
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

    }
}
