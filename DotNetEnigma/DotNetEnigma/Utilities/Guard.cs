using System;

namespace DotNetEnigma.Utilities
{
    public static class Guard
    {
        public static void IsNotNull(object argumentValue, string argumentName)
        {
            if (argumentValue == null)
                throw new ArgumentNullException(argumentName);
        }

        public static void IsNotEqualTo(object argumentValue, object invalidValue, string argumentName)
        {
            if (argumentValue.Equals(invalidValue))
                throw new ArgumentException("Invalid value provided for argument.", argumentName);
        }
    }
}
