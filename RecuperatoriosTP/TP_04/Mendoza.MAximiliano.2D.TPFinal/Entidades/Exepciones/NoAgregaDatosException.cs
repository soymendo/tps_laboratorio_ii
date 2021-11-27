using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exepciones
{
    public class NoAgregaDatosException : Exception
    {
        public NoAgregaDatosException()
        {
        }

        public NoAgregaDatosException(string message) : base(message)
        {
        }

        public NoAgregaDatosException(string message, Exception innerException) : base(message, innerException)
        {
        }

       
    }
}
