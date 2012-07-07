namespace FactoryPlus.Extensions
{
    using System;

    internal static class ObjectExtensions
    {
        public static void VerifyNotNull(this object value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }
    }
}
