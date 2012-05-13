using System;

namespace FactoryPlus
{
    using System.Collections.Generic;

    using FactoryPlus.Build;

    public class FactorySession : IFactorySession
    {
        #region Globals

        private readonly Dictionary<Type, IBuilder> builders = new Dictionary<Type, IBuilder>();

        #endregion

        #region IFactorySession Members

        public void Define<T>(Func<T> construct)
        {
            builders.Add(typeof(T), new DelegateBuilder<T>(construct));
        }

        public T Get<T>()
        {
            IBuilder builder;

            if (builders.TryGetValue(typeof(T), out builder))
            {
                return ((IBuilder<T>)builder).Build();
            }

            throw new ArgumentException(string.Format("No build method defined for type {0}.", typeof(T)));
        }

        #endregion
    }
}