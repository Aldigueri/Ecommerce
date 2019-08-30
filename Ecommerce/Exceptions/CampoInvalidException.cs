using System;
using System.Runtime.Serialization;

namespace Ecommerce.Exceptions
{
    [Serializable]
    internal class CampoInvalidException : Exception
    {
        public CampoInvalidException()
        {
        }

        public CampoInvalidException(string message) : base(message)
        {
        }

        public CampoInvalidException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CampoInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}