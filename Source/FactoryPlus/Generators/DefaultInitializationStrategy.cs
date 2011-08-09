using System;

namespace FactoryPlus.Generators
{
    public class DefaultInitializationStrategy<T> : IInitalizationStrategy<T>
    {
        #region DefaultInitializationStrategy<T> Members

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        #endregion
    }
}
