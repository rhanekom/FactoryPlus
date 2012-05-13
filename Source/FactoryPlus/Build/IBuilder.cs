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
    public interface IBuilder<out T> : IBuilder
    {
        /// <summary>
        /// Builds an instance of the builder type.
        /// </summary>
        /// <returns>An instance of the builder type.</returns>
        new T Build();
    }
}
