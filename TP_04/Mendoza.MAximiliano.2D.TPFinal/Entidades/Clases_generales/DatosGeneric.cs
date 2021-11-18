using Entidades.Clases_especializadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases_generales
{
    /// <summary>
    /// Clase generica , la cual deriva de una clase Hardware que tenga un constructor sin parametros
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public class DatosGeneric<T>
        where T:Hardware, new()
    {
        private List<T> hardware;

        /// <summary>
        /// cosntructor, inicializo la lista
        /// </summary>
        public DatosGeneric()
        {
            this.hardware = new List<T>();
        }


        /// <summary>
        /// Verifico si un hardware esta dentro de los datos
        /// </summary>
        /// <param name="d"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public static bool operator==(DatosGeneric<T> d, Hardware h)
        {
            bool retorno = false;
            if(d.hardware is not null)
            {
                foreach (T item in d.hardware)
                {
                    if(item == h)
                    {
                        retorno = true;
                    }
                }
            }
            return retorno;
        }

        public static bool operator !=(DatosGeneric<T> d, Hardware h)
        {
            return !(d == h);
        }


        /// <summary>
        /// AGrego un hardware dentro de los datos
        /// </summary>
        /// <param name="d"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public static bool operator+(DatosGeneric<T> d, Hardware h)
        {
            bool retorno = false;
            if(d!=h)
            {
                d.hardware.Add((T)h);
                retorno = true;
            }
            return retorno;
        }



        /// <summary>
        /// Elimino un hardware dentro de los datos
        /// </summary>
        /// <param name="d"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public static bool operator -(DatosGeneric<T> d, Hardware h)
        {
            bool retorno = false;
            if (d == h)
            {
                d.hardware.Remove((T)h);
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Muestro la lista de hardware dentro de los datos
        /// </summary>
        /// <returns></returns>
        public string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine();

            foreach (Hardware item in this.hardware)
            {

                sb.AppendLine(item.Informar());

            }
            return sb.ToString();
        }

        /// <summary>
        /// Notifico la cantidad de datos guardados
        /// </summary>
        /// <returns></returns>
        public int CantidadDatos()
        {
            return this.hardware.Count;
        }

        /// <summary>
        /// Devuelvo una lista del tipo T
        /// </summary>
        /// <returns></returns>
        public List<T>ListarHardware()
        {
            return this.hardware;
        }

    }
}
