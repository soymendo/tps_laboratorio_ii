using Entidades.Exepciones;
using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Archivos
{
    public class Texto : IArchivoTexto<string>
    {
        private string datos;
        public string Datos
        {
            get { return this.datos; }
            set { this.datos = value; }
        }

        /// <summary>
        /// Guarda en formato txt 
        /// </summary>
        /// <param name="ruta"></param>
        public void Guardar(string ruta)
        {
            StreamWriter writer = null;
          
            try
            {
                using (writer = new StreamWriter(ruta))
                {
                    writer.Write(Datos);
                    
                }
            }
            catch (Exception )
            {
                throw new ArchivoException("Error en el archivo");
            }
            
        }

     
    }
}
