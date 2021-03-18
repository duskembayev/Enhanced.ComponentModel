using System;
using System.Runtime.Serialization;

namespace Enhanced.ComponentModel
{
    [Serializable]
    public class RegistrationException : Exception
    {
        protected RegistrationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        internal RegistrationException()
        {
        }

        internal RegistrationException(string message) : base(message)
        {
        }

        internal RegistrationException(string message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}