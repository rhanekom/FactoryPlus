namespace FactoryPlus.Build
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An abstract base class for building <see cref="IBuilder{T}"/>
    /// </summary>
    /// <typeparam name="T">The type of object that this builder builds.</typeparam>
    public abstract class BuilderBase<T> : IBuilder<T>
    {
        #region IBuilder<T> Members

        /// <summary>
        /// Builds an instance of the builder type.
        /// </summary>
        /// <returns>An instance of the builder type.</returns>
        public abstract T Build();

        /// <summary>
        /// Builds many instances of the builder type.
        /// </summary>
        /// <param name="howMany">How many instances to build.</param>
        /// <returns>A list of built instances of the builder type.</returns>
        public IList<T> BuildMany(int howMany)
        {
            if (howMany <= 0)
            {
                throw new ArgumentOutOfRangeException("howMany");
            }

            var items = new T[howMany];

            for (int i = 0; i < howMany; i++)
            {
                items[i] = Build();
            }

            return items;
        }

        #endregion

        #region IBuilder Members

        object IBuilder.Build()
        {
            return this.Build();
        }

        #endregion
    }
}