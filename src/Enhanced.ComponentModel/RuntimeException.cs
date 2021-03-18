using System;
using System.Runtime.Serialization;

namespace Enhanced.ComponentModel
{
    public class RuntimeException : Exception
    {
        protected RuntimeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        internal RuntimeException()
        {
        }

        internal RuntimeException(string? message) : base(message)
        {
        }

        internal RuntimeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}