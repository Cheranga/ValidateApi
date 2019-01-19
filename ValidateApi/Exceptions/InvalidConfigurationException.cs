using System;

namespace ValidateApi.Exceptions
{
    public class InvalidConfigurationException : Exception
    {
        public Type ConfigurationType { get; }

        public InvalidConfigurationException(Type configurationType, string message) : base(message)
        {
            ConfigurationType = configurationType;
        }
    }
}