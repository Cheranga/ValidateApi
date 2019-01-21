using System;

namespace ValidateConfig.Exceptions
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