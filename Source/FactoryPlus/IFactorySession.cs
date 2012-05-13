using System;

namespace FactoryPlus
{
    /// <summary>
    /// A factory for use in a single session.  Responsible for storing configuration and constructing objects as needed.
    /// </summary>
    public interface IFactorySession
    {
        /// <summary>
        /// Defines the construction mechanism for a type of object.
        /// </summary>
        /// <typeparam name="T">The type of object to define the construction mechanism for.</typeparam>
        /// <param name="construct">The construction mechanism for the object.</param>
        void Define<T>(Func<T> construct);
        
        /// <summary>
        /// Builds and returns an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to build.</typeparam>
        /// <returns>A new instance of the specified type.</returns>
        T Get<T>();
    }
}
