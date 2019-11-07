using System;
using System.Runtime.Serialization;

namespace DotNetEnigma.Enigma.Plugboard
{
    public class PlugboardConfigurationException : Exception
    {
        public PlugboardConfigurationException()
        {
        }

        public PlugboardConfigurationException(string message) : base(message)
        {
        }

        public PlugboardConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PlugboardConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
