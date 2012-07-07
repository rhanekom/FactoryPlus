namespace FactoryPlus
{
    using System;
    using Build;

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
        /// <exception cref="ArgumentNullException">If <param name="construct"></param> is <c>null</c>.</exception>
        void Define<T>(Func<T> construct);

        /// <summary>
        /// Defines the construction mechanism for a named instance of a type of object.
        /// </summary>
        /// <typeparam name="T">The type of object to define the construction mechanism for.</typeparam>
        /// <param name="name">The instance name of the object.</param>
        /// <param name="construct">The construction mechanism for the object.</param>
        /// <exception cref="ArgumentNullException">If <param name="name"></param> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">If <param name="construct"></param> is <c>null</c>.</exception>
        void Define<T>(string name, Func<T> construct);

        /// <summary>
        /// Builds and returns an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to build.</typeparam>
        /// <returns>A new instance of the specified type.</returns>
        /// <exception cref="BuildException">If no build definition has been defined for the specified type.</exception>
        T Get<T>();

        /// <summary>
        /// Builds and returns an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to build.</typeparam>
        /// <param name="name">The instance name of the object.</param>
        /// <returns>A new instance of the specified type.</returns>
        /// <exception cref="ArgumentNullException">If name is <c>null</c>.</exception>
        /// <exception cref="BuildException">If no build definition has been defined with the specified name.</exception>
        T Get<T>(string name);
    }
}
