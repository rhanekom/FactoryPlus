using System;
using FactoryPlus.Configuration;

namespace FactoryPlus
{
    public static class Factory
    {
        public static void Setup<T>(Action<ISetupExpression> how)
        {
            throw new System.NotImplementedException();
        }

        public static IBuildExpression<T> Default<T>()
        {
            throw new System.NotImplementedException();
        }

        public static IBuildExpression<T> Template<T>(string fromTemplate)
        {
            throw new System.NotImplementedException();
        }
    }
}
