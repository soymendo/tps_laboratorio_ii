using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exepciones
{
    public class ArchivoException : Exception
    {
        public ArchivoException()
        {
        }

        public ArchivoException(string message) : base(message)
        {
        }

        public ArchivoException(string message, Exception innerException) : base(message, innerException)
        {
        }

      
    }
}
