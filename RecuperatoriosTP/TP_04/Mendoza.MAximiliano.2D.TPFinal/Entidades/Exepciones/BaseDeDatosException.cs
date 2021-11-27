using System;
using System.Runtime.Serialization;

namespace Entidades.Clases_especializadas
{
    [Serializable]
    public class BaseDeDatosException : Exception
    {
        public BaseDeDatosException()
        {
        }

        public BaseDeDatosException(string message) : base(message)
        {
        }

        public BaseDeDatosException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BaseDeDatosException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}