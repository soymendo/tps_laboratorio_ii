using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
   public interface IArchvoXml
    {
        /// <summary>
        /// guarda en formato xml
        /// </summary>
        /// <param name="ruta"></param>
        void Guardar(string ruta);

        /// <summary>
        /// Lee en formato xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruta"></param>
        /// <returns></returns>
        T Leer<T>(string ruta) where T : class;
    }
}
