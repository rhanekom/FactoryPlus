namespace FactoryPlus
{
    using System;
    using Build;
    using Extensions;

    public class FactorySession : IFactorySession
    {
        #region Globals

        private readonly BuildDefinitionCollection builders = new BuildDefinitionCollection();

        #endregion

        #region IFactorySession Members

        /// <summary>
        /// Defines the construction mechanism for a type of object.
        /// </summary>
        /// <typeparam name="T">The type of object to define the construction mechanism for.</typeparam>
        /// <param name="construct">The construction mechanism for the object.</param>
        /// <exception cref="ArgumentNullException">If <param name="construct"></param> is <c>null</c>.</exception>
        public void Define<T>(Func<T> construct)
        {
            construct.VerifyNotNull("construct");
            
            builders.AddBuilder(new DelegateBuilder<T>(construct));
        }

        /// <summary>
        /// Defines the construction mechanism for a named instance of a type of object.
        /// </summary>
        /// <typeparam name="T">The type of object to define the construction mechanism for.</typeparam>
        /// <param name="name">The instance name of the object.</param>
        /// <param name="construct">The construction mechanism for the object.</param>
        /// <exception cref="ArgumentNullException">If <param name="name"></param> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">If <param name="construct"></param> is <c>null</c>.</exception>
        public void Define<T>(string name, Func<T> construct)
        {
            name.VerifyNotNull("name");
            construct.VerifyNotNull("construct");
            
            builders.AddBuilder(name, new DelegateBuilder<T>(construct));
        }

        /// <summary>
        /// Builds and returns an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to build.</typeparam>
        /// <returns>A new instance of the specified type.</returns>
        /// <exception cref="BuildException">If no build definition has been defined for the specified type.</exception>
        public T Get<T>()
        {
            IBuilder builder = builders.GetBuilder<T>();

            if (builder == null)
            {
                throw new BuildException(string.Format("No build method defined for type {0}.", typeof(T)));
            }

            return ((IBuilder<T>)builder).Build();
        }

        /// <summary>
        /// Builds and returns an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to build.</typeparam>
        /// <param name="name">The instance name of the object.</param>
        /// <returns>A new instance of the specified type.</returns>
        /// <exception cref="ArgumentNullException">If <param name="name"></param> is <c>null</c>.</exception>
        /// <exception cref="BuildException">If no build definition has been defined with the specified name.</exception>
        public T Get<T>(string name)
        {
            name.VerifyNotNull("name");

            IBuilder builder = builders.GetBuilder<T>(name);

            if (builder == null)
            {
                throw new BuildException(string.Format("No build method defined for type {0}, named instance {1}.", typeof(T), name));
            }

            return ((IBuilder<T>)builder).Build();
        }

        #endregion
    }
}