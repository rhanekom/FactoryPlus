using System.Collections.Generic;

namespace FactoryPlus.Build
{
    /// <summary>
    /// A builder of objects.
    /// </summary>
    public interface IBuilder
    {
        /// <summary>
        /// Builds an instance of the builder type.
        /// </summary>
        /// <returns>An instance of the builder type.</returns>
        object Build();
    }

    /// <summary>
    /// A builder of objects.
    /// </summary>
    /// <typeparam name="T">The type of object created.</typeparam>
    public interface IBuilder<T> : IBuilder
    {
        /// <summary>
        /// Builds an instance of the builder type.
        /// </summary>
        /// <returns>An instance of the builder type.</returns>
        new T Build();

        /// <summary>
        /// Builds many instances of the builder type.
        /// </summary>
        /// <param name="howMany">How many instances to build.</param>
        /// <returns>A list of built instances of the builder type.</returns>
        IList<T> BuildMany(int howMany);
    }
}
