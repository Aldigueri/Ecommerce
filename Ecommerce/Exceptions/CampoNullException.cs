using System;
using System.Runtime.Serialization;

namespace Ecommerce.Exceptions
{
    [Serializable]
    internal class CampoNullException : Exception
    {
        public CampoNullException()
        {
        }

        public CampoNullException(string message) : base(message)
        {
        }

        public CampoNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CampoNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}