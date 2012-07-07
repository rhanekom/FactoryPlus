using System.Collections.Generic;
using FactoryPlus.Build;

namespace FactoryPlus
{
    using System;

    /// <summary>
    /// A static instance of a FactorySession for convenience.
    /// </summary>
    public static class Factory
    {
        #region Construction

        /// <summary>
        /// Initializes static members of the <see cref="Factory"/> class. 
        /// </summary>
        static Factory()
        {
            FactorySession = new FactorySession();
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// Gets or sets the factory session.
        /// </summary>
        /// <value>
        /// The factory session.
        /// </value>
        internal static IFactorySession FactorySession { get; set; }

        #endregion

        #region FactorySession Wrappers

        /// <summary>
        /// Defines the construction mechanism for a type of object.
        /// </summary>
        /// <typeparam name="T">The type of object to define the construction mechanism for.</typeparam>
        /// <param name="construct">The construction mechanism for the object.</param>
        public static void Define<T>(Func<T> construct)
        {
            FactorySession.Define(construct);
        }

        /// <summary>
        /// Builds and returns an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to build.</typeparam>
        /// <returns>A new instance of the specified type.</returns>
        public static T Get<T>()
        {
            return FactorySession.Get<T>();
        }

        /// <summary>
        /// Builds and returns an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to build.</typeparam>
        /// <param name="name">The instance name of the object.</param>
        /// <returns>A new instance of the specified type.</returns>
        public static T Get<T>(string name)
        {
            return FactorySession.Get<T>(name);
        }

        /// <summary>
        /// Defines the construction mechanism for a named instance of a type of object.
        /// </summary>
        /// <typeparam name="T">The type of object to define the construction mechanism for.</typeparam>
        /// <param name="name">The instance name of the object.</param>
        /// <param name="construct">The construction mechanism for the object.</param>
        public static void Define<T>(string name, Func<T> construct)
        {
            FactorySession.Define(name, construct);
        }

        /// <summary>
        /// Builds and returns the specified amount of instances of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to build.</typeparam>
        /// <param name="howMany">How many instances of the type of object to build.</param>
        /// <returns>A list of new instances of the specified type.</returns>
        public static IList<T> GetMany<T>(int howMany)
        {
            return FactorySession.GetMany<T>(howMany);
        }

        /// <summary>
        /// Builds and returns the specified amount of instances of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to build.</typeparam>
        /// <param name="name">The instance name of the object.</param>
        /// <param name="howMany">How many instances of the type of object to build.</param>
        /// <returns>A list of new instances of the specified type.</returns>
        public static IList<T> GetMany<T>(string name, int howMany)
        {
            return FactorySession.GetMany<T>(name, howMany);
        }

        #endregion
    }
}
