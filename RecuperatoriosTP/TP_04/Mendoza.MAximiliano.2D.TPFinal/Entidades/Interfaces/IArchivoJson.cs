using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    interface IArchivoJson
    {
        /// <summary>
        /// Guarda en formato json
        /// </summary>
        /// <param name="rutam"></param>
        /// <param name="contenido"></param>
        void Guardar(string rutam, string contenido);
       
    }
}
