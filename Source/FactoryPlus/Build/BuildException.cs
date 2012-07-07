namespace FactoryPlus.Build
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// An exception that occurs during the construction of an object by a builder.
    /// </summary>
    [Serializable]
    public class BuildException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuildException" /> class.
        /// </summary>
        public BuildException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public BuildException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The inner exception.</param>
        public BuildException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildException" /> class.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="context">The context.</param>
        protected BuildException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
